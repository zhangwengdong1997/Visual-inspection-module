using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HalconDotNet;

namespace 标准视觉软件
{
    public partial class 字符识别参数设置 : UserControl, 检测参数设置
    {
        HWindow hWindow;
        public 字符识别参数设置()
        {
            InitializeComponent();
        }
        private void 字符识别参数设置_Load(object sender, EventArgs e)
        {
            initial();
        }
        public void initial()
        {
            FileOperation.CreateDirectory("OCR");
            FileOperation.BindAllFiles(Application.StartupPath + "\\OCR\\", cmb选择字体库);
        }

        public List<Parameter> initParameterList()
        {
            List<Parameter> parameterList = new List<Parameter>();
            Parameter ocrClassifier = new Parameter("字体库", ParameterType.文件);
            Parameter targetText = new Parameter("标准文本", ParameterType.文字);
            Parameter textLength = new Parameter("识别长度", ParameterType.数字);
            Parameter isInvert = new Parameter("白底黑字", ParameterType.是否);
            Parameter region = new Parameter("识别区域", ParameterType.区域);
            parameterList.Add(ocrClassifier);
            parameterList.Add(targetText);
            parameterList.Add(textLength);
            parameterList.Add(isInvert);
            parameterList.Add(region);
            return parameterList;
        }

        public void Save(ref List<Parameter> parameterList)
        {
            parameterList[0].value = cmb选择字体库.Text;
            parameterList[1].value = txt标准文本.Text;
            parameterList[2].value = -1;
            if (rdo白底黑字.Checked)
            {
                parameterList[3].value = false;
            }
            else
            {
                parameterList[3].value = true;
            }
            float row1, column1, row2, column2;
            row1 = float.Parse(txtRow1.Text);
            column1 = float.Parse(txtColumn1.Text);
            row2 = float.Parse(txtRow2.Text);
            column2 = float.Parse(txtColumn2.Text);
            parameterList[4].value = new float[4] { row1, column1, row2, column2 };
        }

        public void SetHalconWindow(HWindow hWindow)
        {
            this.hWindow = hWindow;
        }

        private void btn选择区域_Click(object sender, EventArgs e)
        {
            btn选择区域.Enabled = false;
            this.Focus();
            HTuple hv_row1;
            HTuple hv_column1;
            HTuple hv_row2;
            HTuple hv_column2;
            HObject ho_Region;

            HOperatorSet.DrawRectangle1(hWindow, out hv_row1, out hv_column1, out hv_row2, out hv_column2);
            HOperatorSet.GenRectangle1(out ho_Region, hv_row1, hv_column1, hv_row2, hv_column2);
            HOperatorSet.SetDraw(hWindow, "margin");
            HOperatorSet.SetColor(hWindow, "red");
            HOperatorSet.DispObj(ho_Region, hWindow);
            txtRow1.Text = hv_row1.D.ToString();
            txtColumn1.Text = hv_column1.D.ToString();
            txtRow2.Text = hv_row2.D.ToString();
            txtColumn2.Text = hv_column2.D.ToString();

            btn选择区域.Enabled = true;
        }

        public string GetName()
        {
            return "字符识别";
        }

        public bool Prepare(List<Parameter> inParameters)
        {
            return true;
        }

        public void Find(HObject inImage, List<Parameter> inParameters, out string outMessage)
        {
            string ocrClassifier = Application.StartupPath + "\\OCR\\" + inParameters[0].value as string;
            string standardText = inParameters[1].value as string;
            int charCount = (int)inParameters[2].value;
            int lightOnDark = (bool)inParameters[3].value ? 1 : 0;

            float row1, column1, row2, column2;
            row1 = (inParameters[4].value as float[])[0];
            column1 = (inParameters[4].value as float[])[1];
            row2 = (inParameters[4].value as float[])[2];
            column2 = (inParameters[4].value as float[])[3];
            HObject ho_inRegion;
            HOperatorSet.GenRectangle1(out ho_inRegion, row1, column1, row2, column2);
            HTuple hv_Word;
            myOcrSplit(inImage, ho_inRegion, ocrClassifier, standardText, charCount, 0, lightOnDark, out hv_Word);
            outMessage = hv_Word.S;
        }

        public int myOcrSplit(HObject ho_inImage, HObject ho_inRegion, HTuple hv_ocrClassifier,
            HTuple hv_standardText, HTuple hv_charCount, HTuple hv_returnPunctuation, HTuple hv_lightOnDark,
            out HTuple hv_Word)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_Timg1 = null, ho_ImageReduced, ho_Region = null;
            HObject ho_Characters = null;

            // Local control variables 

            HTuple hv_step = null, hv_stepMax = null, hv_useEnhanced = null;
            HTuple hv_TextModel = null, hv_OCRHandle = null, hv_RegularExpression = null;
            HTuple hv_UsedThreshold = new HTuple(), hv_Area = new HTuple();
            HTuple hv_Row = new HTuple(), hv_Column = new HTuple();
            HTuple hv_Area1 = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), hv_findText = new HTuple();
            HTuple hv_bufferCount = new HTuple(), hv_bufferMincontrast = new HTuple();
            HTuple hv_Index = new HTuple(), hv_add = new HTuple();
            HTuple hv_TextResultID = new HTuple(), hv_Class = new HTuple();
            HTuple hv_Confidence = new HTuple(), hv_Score = new HTuple();
            HTuple hv_Number = new HTuple(), hv_ScoreSum = new HTuple();
            HTuple hv_Index1 = new HTuple(), hv_Length = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Timg1);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_Characters);
            hv_Word = new HTuple();

            ho_Timg1.Dispose();
            ho_Timg1 = ho_inImage.CopyObj(1, -1);

            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(ho_Timg1, ho_inRegion, out ho_ImageReduced);
            hv_step = 3;
            hv_stepMax = 25;
            hv_useEnhanced = 1;
            HOperatorSet.CreateTextModelReader("auto", hv_ocrClassifier, out hv_TextModel);
            HOperatorSet.ReadOcrClassCnn(hv_ocrClassifier, out hv_OCRHandle);
            HOperatorSet.SetTextModelParam(hv_TextModel, "separate_touching_chars", "enhanced");

            HOperatorSet.SetTextModelParam(hv_TextModel, "return_separators", "true");
            HOperatorSet.SetTextModelParam(hv_TextModel, "add_fragments", "true");
            HOperatorSet.SetTextModelParam(hv_TextModel, "return_punctuation", hv_returnPunctuation == 0 ? "false" : "true");
            //RegularExpression := ''

            //字符串转正则表达式
            myStringToRegular(hv_standardText, out hv_RegularExpression);
            hv_RegularExpression = ("(" + hv_RegularExpression) + ")";


            //判断是否需要反转颜色
            if ((int)(new HTuple(hv_lightOnDark.TupleEqual(1))) != 0)
            {

                HObject ExpTmpOutVar_0;
                HOperatorSet.InvertImage(ho_ImageReduced, out ExpTmpOutVar_0);
                ho_ImageReduced.Dispose();
                ho_ImageReduced = ExpTmpOutVar_0;

            }
            else if ((int)(new HTuple(hv_lightOnDark.TupleEqual(2))) != 0)
            {

                ho_Region.Dispose();
                HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability",
                    "dark", out hv_UsedThreshold);
                HOperatorSet.AreaCenter(ho_ImageReduced, out hv_Area, out hv_Row, out hv_Column);
                HOperatorSet.AreaCenter(ho_Region, out hv_Area1, out hv_Row1, out hv_Column1);
                if ((int)(new HTuple(hv_Area1.TupleGreater(hv_Area / 2))) != 0)
                {
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.InvertImage(ho_ImageReduced, out ExpTmpOutVar_0);
                        ho_ImageReduced.Dispose();
                        ho_ImageReduced = ExpTmpOutVar_0;
                    }
                }
            }
            //以置信度最高为分割目标
            if ((int)(new HTuple(hv_charCount.TupleEqual(0))) != 0)
            {
                hv_findText = 0;
                hv_bufferCount = 0;
                hv_bufferMincontrast = 5;
                HTuple end_val52 = hv_stepMax;
                HTuple step_val52 = 1;
                for (hv_Index = 1; hv_Index.Continue(end_val52, step_val52); hv_Index = hv_Index.TupleAdd(step_val52))
                {

                    hv_add = hv_step * hv_Index;
                    HOperatorSet.SetTextModelParam(hv_TextModel, "min_contrast", hv_add);
                    HOperatorSet.FindText(ho_ImageReduced, hv_TextModel, out hv_TextResultID);
                    ho_Characters.Dispose();
                    HOperatorSet.GetTextObject(out ho_Characters, hv_TextResultID, "all_lines");
                    HOperatorSet.DoOcrWordCnn(ho_Characters, ho_ImageReduced, hv_OCRHandle, hv_RegularExpression,
                        3, 10, out hv_Class, out hv_Confidence, out hv_Word, out hv_Score);
                    HOperatorSet.CountObj(ho_Characters, out hv_Number);
                    HOperatorSet.TupleSum(hv_Confidence, out hv_ScoreSum);
                    HOperatorSet.TupleFindFirst(hv_Class, "\x1A", out hv_Index1);
                    if ((int)((new HTuple(hv_bufferCount.TupleLess(hv_ScoreSum))).TupleAnd(new HTuple(hv_Index1.TupleEqual(
                        -1)))) != 0)
                    {
                        hv_findText = 1;
                        hv_bufferCount = hv_ScoreSum.Clone();
                        hv_bufferMincontrast = hv_add.Clone();
                    }
                }
                HOperatorSet.SetTextModelParam(hv_TextModel, "min_contrast", hv_bufferMincontrast);
                HOperatorSet.FindText(ho_ImageReduced, hv_TextModel, out hv_TextResultID);
                ho_Characters.Dispose();
                HOperatorSet.GetTextObject(out ho_Characters, hv_TextResultID, "all_lines");
                HOperatorSet.DoOcrWordCnn(ho_Characters, ho_ImageReduced, hv_OCRHandle, hv_RegularExpression,
                    3, 10, out hv_Class, out hv_Confidence, out hv_Word, out hv_Score);

            }


            //以识别字符为固定长度为分割目标
            if ((int)(new HTuple(hv_charCount.TupleGreater(0))) != 0)
            {
                hv_findText = 0;
                hv_bufferCount = 0;
                hv_bufferMincontrast = 5;
                HTuple end_val86 = hv_stepMax;
                HTuple step_val86 = 1;
                for (hv_Index = 1; hv_Index.Continue(end_val86, step_val86); hv_Index = hv_Index.TupleAdd(step_val86))
                {

                    hv_add = hv_step * hv_Index;
                    HOperatorSet.SetTextModelParam(hv_TextModel, "min_contrast", hv_add);
                    HOperatorSet.FindText(ho_ImageReduced, hv_TextModel, out hv_TextResultID);
                    ho_Characters.Dispose();
                    HOperatorSet.GetTextObject(out ho_Characters, hv_TextResultID, "all_lines");

                    HOperatorSet.CountObj(ho_Characters, out hv_Number);

                    if ((int)(new HTuple(hv_charCount.TupleEqual(hv_Number))) != 0)
                    {
                        hv_findText = 1;
                        //
                        HOperatorSet.DoOcrWordCnn(ho_Characters, ho_ImageReduced, hv_OCRHandle,
                            hv_RegularExpression, 3, 10, out hv_Class, out hv_Confidence, out hv_Word,
                            out hv_Score);
                        HOperatorSet.TupleSum(hv_Confidence, out hv_ScoreSum);
                        HOperatorSet.TupleFindFirst(hv_Class, "\x1A", out hv_Index1);
                        if ((int)((new HTuple(hv_bufferCount.TupleLess(hv_ScoreSum))).TupleAnd(
                            new HTuple(hv_Index1.TupleEqual(-1)))) != 0)
                        {
                            hv_findText = 1;
                            hv_bufferCount = hv_ScoreSum.Clone();
                            hv_bufferMincontrast = hv_add.Clone();
                        }

                    }

                }
                //以置信度最高为分割目标 再识别一次
                //if (findText == 0)
                HOperatorSet.SetTextModelParam(hv_TextModel, "min_contrast", hv_bufferMincontrast);
                HOperatorSet.FindText(ho_ImageReduced, hv_TextModel, out hv_TextResultID);
                ho_Characters.Dispose();
                HOperatorSet.GetTextObject(out ho_Characters, hv_TextResultID, "all_lines");
                HOperatorSet.DoOcrWordCnn(ho_Characters, ho_ImageReduced, hv_OCRHandle, hv_RegularExpression,
                    3, 10, out hv_Class, out hv_Confidence, out hv_Word, out hv_Score);
                //endif
            }

            //使用标准文本对比
            if ((int)(new HTuple(hv_charCount.TupleLess(0))) != 0)
            {

                //判断是否和标准文本一致

                hv_findText = 0;
                hv_bufferCount = 0;
                hv_bufferMincontrast = 5;
                HTuple end_val130 = hv_stepMax;
                HTuple step_val130 = 1;
                for (hv_Index = 1; hv_Index.Continue(end_val130, step_val130); hv_Index = hv_Index.TupleAdd(step_val130))
                {
                    hv_add = hv_step * hv_Index;
                    HOperatorSet.SetTextModelParam(hv_TextModel, "min_contrast", hv_add);
                    HOperatorSet.FindText(ho_ImageReduced, hv_TextModel, out hv_TextResultID);
                    ho_Characters.Dispose();
                    HOperatorSet.GetTextObject(out ho_Characters, hv_TextResultID, "all_lines");
                    HOperatorSet.CountObj(ho_Characters, out hv_Number);
                    HOperatorSet.TupleStrlen(hv_standardText, out hv_Length);
                    if ((int)(new HTuple(hv_Length.TupleNotEqual(hv_Number))) != 0)
                    {
                        continue;
                    }
                    HOperatorSet.DoOcrWordCnn(ho_Characters, ho_ImageReduced, hv_OCRHandle, hv_RegularExpression,
                        5, 10, out hv_Class, out hv_Confidence, out hv_Word, out hv_Score);

                    if ((int)(new HTuple(hv_Word.TupleEqual(hv_standardText))) != 0)
                    {
                        hv_findText = 1;
                        break;
                    }

                    HOperatorSet.TupleSum(hv_Confidence, out hv_ScoreSum);
                    HOperatorSet.TupleFindFirst(hv_Class, "\x1A", out hv_Index1);
                    if ((int)((new HTuple(hv_bufferCount.TupleLess(hv_ScoreSum))).TupleAnd(new HTuple(hv_Index1.TupleEqual(
                        -1)))) != 0)
                    {

                        hv_bufferCount = hv_ScoreSum.Clone();
                        hv_bufferMincontrast = hv_add.Clone();
                    }
                }
                //以置信度最高为分割目标 再识别一次
                if ((int)(new HTuple(hv_findText.TupleEqual(0))) != 0)
                {
                    HOperatorSet.SetTextModelParam(hv_TextModel, "min_contrast", hv_bufferMincontrast);
                    HOperatorSet.FindText(ho_ImageReduced, hv_TextModel, out hv_TextResultID);
                    ho_Characters.Dispose();
                    HOperatorSet.GetTextObject(out ho_Characters, hv_TextResultID, "all_lines");
                    HOperatorSet.DoOcrWordCnn(ho_Characters, ho_ImageReduced, hv_OCRHandle, hv_RegularExpression,
                        5, 10, out hv_Class, out hv_Confidence, out hv_Word, out hv_Score);
                }
            }
            HOperatorSet.ClearTextModel(hv_TextModel);
            HOperatorSet.ClearOcrClassCnn(hv_OCRHandle);
            ho_Timg1.Dispose();
            ho_ImageReduced.Dispose();
            ho_Region.Dispose();
            ho_Characters.Dispose();

            int nRet = 1;
            if (hv_findText == 1) nRet = 0;
            return nRet;
        }

        public void myStringToRegular(HTuple hv_standardText, out HTuple hv_getRegular)
        {
            HTuple hv_regularModel = null, hv_Length = null;
            HTuple hv_Index2 = null, hv_Index3 = new HTuple(), hv_Selected = new HTuple();
            HTuple hv_Matches = new HTuple(), hv_Length2 = new HTuple();
            // Initialize local and output iconic variables 
            hv_getRegular = "";

            hv_regularModel = new HTuple();
            hv_regularModel[0] = "[0-9]";
            hv_regularModel[1] = "[A-Z]";
            hv_regularModel[2] = "[a-z]";
            hv_regularModel[3] = ".";
            HOperatorSet.TupleStrlen(hv_standardText, out hv_Length);

            HTuple end_val5 = hv_Length - 1;
            HTuple step_val5 = 1;
            for (hv_Index2 = 0; hv_Index2.Continue(end_val5, step_val5); hv_Index2 = hv_Index2.TupleAdd(step_val5))
            {
                for (hv_Index3 = 0; (int)hv_Index3 <= 3; hv_Index3 = (int)hv_Index3 + 1)
                {
                    HOperatorSet.TupleStrBitSelect(hv_standardText, hv_Index2, out hv_Selected);
                    HOperatorSet.TupleRegexpMatch(hv_Selected, hv_regularModel.TupleSelect(hv_Index3),
                        out hv_Matches);

                    HOperatorSet.TupleStrlen(hv_Matches, out hv_Length2);
                    if ((int)(new HTuple(hv_Length2.TupleEqual(1))) != 0)
                    {
                        if ((int)(new HTuple(((hv_regularModel.TupleSelect(hv_Index3))).TupleNotEqual("."))) != 0)
                        {
                            hv_getRegular = hv_getRegular + (hv_regularModel.TupleSelect(hv_Index3));
                            break;
                        }
                        else
                        {
                            hv_getRegular = hv_getRegular + hv_Selected;
                        }
                    }
                }
            }
            return;
        }
    }
}

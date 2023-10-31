using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Word = Microsoft.Office.Interop.Word;

namespace GroupManager.Models
{
    public class CharacteristicManager
    {
        private void SetDefaultTextType(Range range)
        {
            range.Font.Size = 14;
            range.Font.Name = "Times New Roman";
           
        }
        public void CreateCharacteristic(CharacteristicModel model,object filename)
        {
            try
            {
                Word.Application word_app = new Word.Application();
                object missing = Type.Missing;
                Word._Document word_doc = word_app.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Word.Paragraph para = word_doc.Paragraphs.Add(ref missing);
                word_doc.Paragraphs.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;


                SetDefaultTextType(para.Range);
                para.Range.Font.Bold = 700;
                para.Range.Text = "ХАРАКТЕРИСТИКА";
                para.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;


                para.Range.InsertParagraphAfter();
                SetDefaultTextType(para.Range);
                para.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                para.Range.Text = model.Name + " " + model.Lastname + " " + model.Patronymic;

                para.Range.InsertParagraphAfter();
                SetDefaultTextType(para.Range);
                string year = model.Student.DateOfBirth.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[2];
                para.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                para.Range.Text = $"{year} року народження";

                para.Range.InsertParagraphAfter();
                para.Range.InsertParagraphAfter();
                SetDefaultTextType(para.Range);
                para.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                string text = $@"{model.Name} {model.Lastname} {model.Patronymic} навчається у Вiдокремленому структурному пiдроздiлi «Полтавський політехнічний фаховий коледж Національного технічного університету «Харківський політехнічний інститут» за спеціальністю {model.Specialization} з {model.StartStudyDate}";
                para.Range.Text = "\t" + text;

                string text2 = "\n\t";
                if (model.IsGoodStudent)
                {
                    text2 += "За період навчання зарекомендував себе з позитивної сторони.";
                }
                else { text2 += "За період навчання зарекомендував себе з негативної сторони"; }

                text2 += $"\n\t{model.Collective}. {model.PhysicalCharacteristic}. {model.Behavior}. {model.PoliceSituations}. {model.AlchogolSituations}. Студент зарекомендував себе як ";
                foreach (var item in model.StudentRecomendations)
                {
                    text2 += item + ", ";
                }

                if (string.IsNullOrEmpty(model.Courses))
                {
                    text2 += $"{model.ReadyToArmy}";
                    para.Range.Text += text2;
                    para.Range.Text += "\n\tХарактеристика видана за місцем вимоги.";
                }
                else
                {
                    text2 += "Під час навчання, студент проходив такі курси:";
                    para.Range.Text += $"{text2} {model.Courses}";
                }


                para.Range.InsertParagraphAfter();
                para.Range.InsertParagraphAfter();
                para.Range.InsertParagraphAfter();
                SetDefaultTextType(para.Range);
                para.Range.Text = DateTime.Now.ToString("dd.MM.yyyy");
                para.Range.InsertParagraphAfter();
                para.Range.InsertParagraphAfter();
                para.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                para.Range.Text = $"Директор коледжу                     {model.Director}\r\n\r\nКерівник групи                     {model.Tutor}\r\n";


                word_doc.SaveAs(ref filename, ref missing, ref missing,

                        ref missing, ref missing, ref missing, ref missing,

                        ref missing, ref missing, ref missing, ref missing,

                        ref missing, ref missing, ref missing, ref missing,

                        ref missing);
                para.Range.InsertParagraphAfter();
                object save_changes = false;
                word_doc.Close(ref save_changes, ref missing, ref missing);
                word_app.Quit(ref save_changes, ref missing, ref missing);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

           
        }
    }
}

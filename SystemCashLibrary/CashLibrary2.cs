using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SystemCashLibrary
{
    public class CashLibrary2
    {
        private string _FilePath;
        private string _FileDirectory;
        public CashLibrary2(string FileName, string Get_FileDirectory)
        {
            _FileDirectory = Directory.GetCurrentDirectory() + "\\" + Get_FileDirectory;
            _FilePath = _FileDirectory + "\\" + FileName;
        }


        //har file ya directory pas az tarif mibayest marahele zir ra tey konad:
        //1.writing
        //2.reading
        StreamReader ReaderObj;
        StreamWriter WriterObj;
        //avala az hame bayad chek shavad yek file ya directory jahate rikhtane chsh dar an vojud darad ya na
        //dar surate adame vojud ejaze sakht darad ya na
        /// <summary>
        /// A good function to write a text to file
        /// </summary>
        /// <param name="TextToWrite">text to write in a file</param>
        /// <param name="CreateFileNotExist">create a file or folder if not exist</param>
        /// <returns> 1 if done ,-1 if file not exist and not allow to create,-2 if cannot write in a file </returns>
        public int ExistAndWriting_File(string TextToWrite,bool CreatingAuthorization)
        {
            if(Directory.Exists(_FileDirectory))
            {
                if(File.Exists(_FilePath))
                {
                    WriterObj = new StreamWriter(_FilePath);
                    WriterObj.WriteLine(TextToWrite);
                    WriterObj.Close();
                    return 1;
                }
                else
                {
                    if(CreatingAuthorization)
                    {
                        File.Create(_FilePath);
                        WriterObj = new StreamWriter(_FilePath);
                        WriterObj.WriteLine(TextToWrite);
                        WriterObj.Close();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                if (CreatingAuthorization)
                {
                    Directory.CreateDirectory(_FileDirectory);
                    File.Create(_FilePath);
                    WriterObj = new StreamWriter(_FilePath);
                    WriterObj.WriteLine(TextToWrite);
                    WriterObj.Close();
                    return 1;
                }

                else
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// This Method Append a text to a file .
        /// </summary>
        /// <param name="TextToAppend">text to append </param>
        /// <returns></returns>
        public int Append_ToFile(string TextToAppend)
        {
            if (Directory.Exists(_FileDirectory))
            {
                if (File.Exists(_FilePath))
                {
                    WriterObj = new StreamWriter(_FilePath, true);
                    WriterObj.WriteLine(TextToAppend);
                    WriterObj.Close();
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }

        }
        /// <summary>
        /// This Method Reads All Line Of A File .
        /// </summary>
        /// <returns>The File Text</returns>
        public string ReadFile()
        {
            string result = "";
            if (File.Exists(_FilePath))
            {
                ReaderObj = new StreamReader(_FilePath);
                result=ReaderObj.ReadToEnd();
                ReaderObj.Close();
                return result;
            }
                return result = "File Not Found";
        }

    }
}

// File: FileManager.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: LEonard file open/clase/scaling system

using System;
using System.Collections.Generic;
using System.IO;

namespace LEonard
{
    public class FileManager
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        MainForm myForm;
        string logPrefix;

        StreamWriter writer = null;
        int writerLineNo = 0;

        StreamReader reader = null;
        int readerLineNo = 0;
        Dictionary<int, double> readerScale = null;


        public FileManager(MainForm form, string prefix = "")
        {
            myForm = form;
            logPrefix = prefix;
        }
        ~FileManager()
        {
            AllClose();
        }
        public bool AllClose()
        {
            return InputClose() && OutputClose();
        }


        public bool InputOpen(string filename)
        {
            InputClose();
            try
            {
                reader = new StreamReader(filename);
                log.Info($"{logPrefix} Opened input file {filename}");
                readerScale = new Dictionary<int, double>();
                readerLineNo = 0;
                myForm.WriteVariable("infile_open", true);
                myForm.WriteVariable("infile_lineno", readerLineNo);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InputClose()
        {
            if (reader != null)
            {
                log.Info($"{logPrefix} Input closing");
                reader.Close();
                myForm.WriteVariable("infile_open", false);
                reader = null;
            }
            return true;
        }
        public bool AddScale(int index, double scale)
        {
            try
            {
                readerScale.Add(index, scale);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsInputOpen()
        {
            return reader != null;
        }

        public string InputReadLine()
        {
            if (reader == null)
                return null;

            readerLineNo++;
            string line = reader.ReadLine();

            if (line == null)
            {
                readerLineNo = -1;
            }
            else
            {
                while (line.StartsWith("skip,"))
                {
                    log.Info($"Skipping {line}");
                    readerLineNo++;
                    line = reader.ReadLine();
                    if (line == null) break;
                }

                myForm.WriteVariable("infile_line", line);

                string[] fields = line.Split(',');
                int i = 0;
                foreach (string field in fields)
                {
                    // Scale factor requested?
                    if (readerScale.TryGetValue(i, out double scale))
                    {
                        try
                        {
                            double x = Convert.ToDouble(field);
                            x *= scale;
                            myForm.WriteVariable($"infile_p{i++}", x);
                        }
                        catch { }
                    }
                    else
                        myForm.WriteVariable($"infile_p{i++}", field);
                }
            }

            myForm.WriteVariable("infile_lineno", readerLineNo);
            return null;
        }

        public bool OutputOpen(string filename, bool fAppend = false)
        {
            OutputClose();
            try
            {
                writer = new StreamWriter(filename, fAppend);
                log.Info($"{logPrefix} Opened output file {filename}");
                return true;
            }
            catch
            {
                log.Error($"{logPrefix} Can't open output {filename}");
                return false;
            }
        }
        public bool OutputClose()
        {
            if (writer != null)
            {
                writer.Close();
                log.Info($"{logPrefix} Closed output file");
                writer = null;
            }
            return true;
        }
        public bool IsOutputOpen()
        {
            return writer != null;
        }
    }
}

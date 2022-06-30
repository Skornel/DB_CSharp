using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD_ROM
{
    public class ConfigManager
    {
        string configPath;
        public ConfigManager(string configPath) {
            this.configPath = configPath;
        }
        public string ReadContentFromConfigFile() {
            string content;
            try
            {
                using (StreamReader sr = new StreamReader(configPath))
                {
                    content = sr.ReadToEnd();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); content = ""; }
            return content;
        }
        public void WriteContentToConfigFile(string content)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(configPath, false))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HostsChanger
{
    class hostsChanger
    {
        static String url = "";
        static String hostsFile = "";

        public static void setTf (String str)
        {
            hostsFile = String.Copy(str);
        }

        public static void setUrl (String u)
        {
            url = u;
        }

        public static String getURL()
        {
            return url;
        }

        public static String getHostsFile()
        {
            return hostsFile;
        }

        public static void setHostsFile(String str)
        {
            hostsFile = str;
        }

        static void saveText()
        {

        }

        public static String Reader ()
        {
            try
            {
                FileStream fs = new FileStream(getURL(), FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
                StreamReader r = new StreamReader(fs);
                hostsFile = r.ReadToEnd();
                r.Close();
                fs.Close();
                return hostsFile;
            }
            catch (UnauthorizedAccessException)
            {
                return "Access denied";
            }
            catch (IOException)
            {
                return "Host not found.";
            }
            catch (ArgumentException)
            {
                return "Please, enter IP Address or Host name.";    
            }
            catch (Exception) { return null; }
        }

        public static void Writer()
        {
            try
            {
                FileStream fs2 = new FileStream(getURL(), FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter w = new StreamWriter(fs2);
                w.Write(getHostsFile());
                w.Close();
                fs2.Close();
            }
            catch (Exception) { }
        }
    }
}

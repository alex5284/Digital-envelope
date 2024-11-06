using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Utilities;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Lifetime;

namespace Kursova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            checkBox1.Checked = true;
        }
        byte[] symmetricKey, IDEA_byte;
        List<int> m2, symmetricKey_e;
        int n, e_rsa, d;
        string Idea_e = "", Rsa_e = "";
        byte[] BBS()
        {
            List<int> B = new List<int> ();
            listBox1.Items.Clear();
            int n = 1000;
            List<int> x = new List<int>();
            for (var i = 0u; i < n; i++)
            {
                if (IsPrimeNumber(i))
                {
                    if(Convert.ToInt32(i)%4 == 3) x.Add(Convert.ToInt32(i));
                }
            }
            Random r = new Random();
            int k = r.Next(27, x.Count);
            int k1 = r.Next(27, x.Count);
            int p = x[k];
            int q = x[k1];
            int s = 0;
            do
            {
                s = r.Next(q, 300000);
                bool t = AreRelativelyPrime(s, p);
                bool t1 = AreRelativelyPrime(s, q);
                if (t == true && t1 == true) break;

            } while (true);
            int n1 = 128;
            List<double> X = new List<double>();
            double N = p * q;
            X.Add((Math.Pow(s, 2)) % N);
            for (int i = 0; i < n1; i++)
            {
                int c1 = (int)DateTime.Now.Millisecond;
                X.Add((Math.Pow(X[i], 2) + Math.Pow(c1, 2)) % N);
                B.Add(Convert.ToInt32(X[i] % 2));
            }

            byte[] bytes = new byte[16];

            for (int i = 0; i < 16; i++)
            {
                byte b = 0;
                for (int j = 0; j < 8; j++)
                {
                    b <<= 1;
                    b |= (byte)B[i * 8 + j];
                }
                bytes[i] = b;
            }
            return bytes;
        }
        
        byte[] IDEAEncrypt(byte[] key, byte[] input)
        {
            BufferedBlockCipher cipher = new BufferedBlockCipher(new CfbBlockCipher(new IdeaEngine(), 64));
            KeyParameter keyParam = new KeyParameter(key);
            cipher.Init(true, new ParametersWithIV(keyParam, new byte[8]));
            byte[] output = new byte[input.Length];
            int outputLength = cipher.ProcessBytes(input, 0, input.Length, output, 0);
            cipher.DoFinal(output, outputLength);
            return output;
        }
        byte[] IDEADecrypt(byte[] key, byte[] input)
        {
            BufferedBlockCipher cipher = new BufferedBlockCipher(new CfbBlockCipher(new IdeaEngine(), 64));
            KeyParameter keyParam = new KeyParameter(key);
            cipher.Init(false, new ParametersWithIV(keyParam, new byte[8]));
            byte[] output = new byte[input.Length];
            int outputLength = cipher.ProcessBytes(input, 0, input.Length, output, 0);
            cipher.DoFinal(output, outputLength);
            return output;
        }

        byte[] MD5(byte[] t1)
        {
            byte[] text = t1;
            List<byte> list;
            list = text.ToList();
            if (text.Length % 64 != 0)
            {
                list.Add(0x80);
                if (list.Count % 64 != 0)
                {
                    do
                    {
                        list.Add(0);
                    } while (list.Count % 64 != 0);
                }
                text = list.ToArray();
            }

            uint A = 0x67452301;
            uint B = 0xefcdab89;
            uint C = 0x98badcfe;
            uint D = 0x10325476;
            for (int i = 0; i < text.Length; i += 64)
            {
                uint[] X = new uint[16];
                for (int j = 0; j < 16; j++)
                {
                    X[j] = BitConverter.ToUInt32(text, i * 64 + j * 4);
                }
                uint A1 = A, B1 = B, C1 = C, D1 = D;
                for (int j = 0; j < 64; j++)
                {
                    A = B + ((A + G(B, C, D, j) + X[g(j)] + T(j)) << S(i));
                    uint t = D;
                    D = C; ;
                    C = A;
                    B = t;
                }
                A = A + A1;
                B = B + B1;
                C = C + C1;
                D = D + D1;
            }
            byte[] a = BitConverter.GetBytes(A);
            byte[] b = BitConverter.GetBytes(B);
            byte[] c = BitConverter.GetBytes(C);
            byte[] d = BitConverter.GetBytes(D);
            List<byte[]> W = new List<byte[]>();
            W.Add(a);
            W.Add(b);
            W.Add(c);
            W.Add(d);
            //string  res = "";
            byte[] r = new byte[a.Length + b.Length + c.Length + d.Length];
            int c1 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    //res += W[i][j].ToString("x2");
                    r[c1] = W[i][j];
                    c1++;
                }
            }
            return r;
        }
        uint T(int i)
        {
            uint t = (uint)(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1)));
            return t;
        }
        int g(int i)
        {
            int g1 = 0;
            if (i < 16)
            {
                g1 = i;
            }
            else if (i > 15 && i < 32)
            {
                g1 = (5 * i + 1) % 16;
            }
            else if (i > 31 && i < 48)
            {
                g1 = (3 * i + 5) % 16;
            }
            else if (i > 47 && i < 64)
            {
                g1 = (7 * i) % 16;
            }
            return g1;
        }
        uint G(uint b, uint c, uint d, int i)
        {
            uint g = 0;
            if (i < 16)
            {
                g = (b & c) | (~b & d);
            }
            else if (i > 15 && i < 32)
            {
                g = (b & d) | (c & ~d);
            }
            else if (i > 31 && i < 48)
            {
                g = b ^ c ^ d;
            }
            else if (i > 47 && i < 64)
            {
                g = c ^ (b | ~d);
            }
            return g;
        }
        int S(int i)
        {
            int[] s = new int[] { 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22 };
            return s[i % 16];
        }
        void Read()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "E:\\Е\\Криптология\\Kursova";

            openFileDialog1.Title = "Выберите файл для чтения данных";

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult result = openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string text = File.ReadAllText(filename);
            tbText.Text = text;
        }
        void Read_parameters()
        {
            if(checkBox2.Checked && radioButton3.Checked)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "E:\\Е\\Криптология\\Kursova";

                openFileDialog1.Title = "Выберите файл для чтения данных";

                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                DialogResult result = openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                string[] lines = File.ReadAllLines(filename);
                string input = lines[0];
                string[] parts = input.Split('=');
                string numberString = parts[1].Trim();
                int p = int.Parse(numberString);
                input = lines[1];
                parts = input.Split('=');
                numberString = parts[1].Trim();
                int q = int.Parse(numberString);
                input = lines[2];
                parts = input.Split('=');
                numberString = parts[1].Trim();
                d = int.Parse(numberString);
                input = lines[3];
                parts = input.Split('=');
                numberString = parts[1].Trim();
                e_rsa = int.Parse(numberString);
                tbp.Text = p.ToString();
                tbq.Text = q.ToString();
                n = p * q;
            }
            else if (checkBox1.Checked && radioButton3.Checked)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "E:\\Е\\Криптология\\Kursova";

                openFileDialog1.Title = "Выберите файл для чтения данных";

                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                DialogResult result = openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                string text = File.ReadAllText(filename);
                tbSymkey.Text = text;
                symmetricKey = Encoding.UTF8.GetBytes(text);
            }
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            Read();
        }

        private void btnIDEA_E_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = true;
            }
            string key1 = "";
            if (checkBox1.Checked && radioButton2.Checked)
            {
                key1 = tbSymkey.Text;
            }
            else if (checkBox1.Checked && radioButton1.Checked)
            {
                symmetricKey = BBS();
                tbSymkey.Text = Convert.ToBase64String(symmetricKey);
                key1 = tbSymkey.Text;
            }
            else if (checkBox1.Checked && radioButton3.Checked)
            {
                Read_parameters();
            }
            string text1 = tbText.Text;
            byte[] text = Encoding.UTF8.GetBytes(text1);
            byte[] key = Encoding.UTF8.GetBytes(key1);
            symmetricKey = key;
            byte[] res = IDEAEncrypt(key, text);
            IDEA_byte = res;
            Idea_e = Convert.ToBase64String(res);

            listBox1.Items.Add("Зашифроване повідомленя за допомогою алгоритму IDEA:");
            listBox1.Items.Add("  " + Idea_e);
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save File";
            saveFileDialog.FileName = "E:\\Е\\Криптология\\Kursova\\IDEA_generate_key.txt";
            string filename = saveFileDialog.FileName;
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(tbSymkey.Text);
            }
        }

        bool IsPrimeNumber(uint n)
        {
            var result = true;

            if (n > 1)
            {
                for (var i = 2u; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
        int ModPow(int a, int b, int m)
        {
            int res = 1;
            a %= m;
            while (b > 0)
            {
                if ((b & 1) != 0)
                    res = (res * a) % m;
                a = (a * a) % m;
                b >>= 1;
            }
            if (res < 0)
                res += m;
            return res;
        }
        void Generate()
        {
            int n = 500;
            List<int> x = new List<int>();
            for (var i = 0u; i < n; i++)
            {
                if (IsPrimeNumber(i))
                {
                    x.Add(Convert.ToInt32(i));
                }
            }
            Random r = new Random();
            int j, k = 1;
            do
            {
                j = r.Next(x.Count);
            } while (j < 3);
            if (x[j] > 100)
            {
                do
                {
                    k = r.Next(x.Count);
                } while (x[k] > 100);
            }
            else
            {
                do
                {
                    k = r.Next(x.Count);
                } while (x[k] < 100);
            }
            tbp.Text = x[j].ToString();
            tbq.Text = x[k].ToString();
        }
        void Generate2()
        {
            Random r = new Random();
            int p = Convert.ToInt32(tbp.Text);
            int q = Convert.ToInt32(tbq.Text);
            n = p * q;
            int f = (p - 1) * (q - 1);
            List<int> e1 = new List<int>();
            List<int> x = new List<int>();
            bool t;
            for (var i = 0u; i < f; i++)
            {
                if (IsPrimeNumber(i))
                {
                    x.Add(Convert.ToInt32(i));
                    t = AreRelativelyPrime(x[x.Count - 1], f);
                    if (t == true) e1.Add(x[x.Count - 1]);
                    if (e1.Count == 10) break;
                }
            }
            int e2 = r.Next(0, e1.Count - 1);
            e_rsa = e1[e2];
            d = FindD(p, q, e_rsa);
        }
        bool AreRelativelyPrime(int a, int b)
        {
            int gcd = 1;
            for (int i = 1; i <= a && i <= b; ++i)
            {
                if (a % i == 0 && b % i == 0)
                    gcd = i;
            }
            return gcd == 1;
        }
        int FindD(int p, int q, int e)
        {
            int phi = (p - 1) * (q - 1);
            int d = 0;
            int k = 1;

            while (true)
            {
                d = (k * phi + 1) / e;

                if (d * e == k * phi + 1)
                    return d;

                k++;
            }
        }
        void Calc()
        {
            if(checkBox1.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
            }
            if (checkBox2.Checked && radioButton1.Checked)
            {
                Generate();
                Generate2();
            }
            else if(checkBox2.Checked && radioButton2.Checked)
            {
                Generate2();
            }
            else if (checkBox2.Checked && radioButton3.Checked)
            {
                Read_parameters();
            }
            string text = tbText.Text;
            byte[] hashBytes = MD5(Encoding.UTF8.GetBytes(text));
            listBox1.Items.Add("");
            listBox1.Items.Add("Хеш поідомлення за алгоритмом MD5:");
            listBox1.Items.Add("  " + Convert.ToBase64String(hashBytes));
            m2 = Encrypt_RSA(hashBytes, d, n);
            string res = "";
            for(int i = 0; i < m2.Count; i++)
            {
                if (i != m2.Count - 1) res += m2[i].ToString() + " ";
                else res += m2[i].ToString();
            }
            Rsa_e = res;
            listBox1.Items.Add("");
            listBox1.Items.Add("Цифровий підпис за алгоритмом RSA:");
            listBox1.Items.Add("  " + res);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save File";
            saveFileDialog.FileName = "E:\\Е\\Криптология\\Kursova\\RSA_generate_keys.txt";
            string filename = saveFileDialog.FileName;
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("p = " + tbp.Text);
                writer.WriteLine("q = " + tbq.Text);
                writer.WriteLine("d = " + d.ToString());
                writer.WriteLine("e = " + e_rsa.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) checkBox2.Checked = false;
            if (checkBox1.Checked == false) checkBox2.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) checkBox1.Checked = false;
            if (checkBox2.Checked == false) checkBox1.Checked = true;
        }

        List<int> Encrypt_RSA(byte[] t1, int d1, int n1)
        {
            byte[] text = t1;
            List<int> c = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                c.Add(ModPow(text[i], d1, n1));
            }
            return c;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void btnReadIdeaKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "E:\\Е\\Криптология\\Kursova";

            openFileDialog1.Title = "Выберите файл для чтения данных";

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult result = openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string[] lines = File.ReadAllLines(filename);
            symmetricKey = Encoding.UTF8.GetBytes(lines[0]);
            tbSymkey.Text = lines[0];
        }

        private void btnReadRSAkeys_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            radioButton3.Checked = true;
            Read_parameters();
        }

        private void btnPerevirka_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "E:\\Е\\Криптология\\Kursova";

            openFileDialog1.Title = "Выберите файл для чтения данных";

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult result = openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string[] lines = File.ReadAllLines(filename);
            string input = lines[0];
            string[] parts = input.Split('=');
            string numberString = parts[1].Trim();
            string[] t = numberString.Split(' ');
            List<byte> text_byte = new List<byte>();
            for(int i = 0; i < t.Length; i++)
            {
                text_byte.Add(Convert.ToByte(t[i]));
            }

            input = lines[1];
            parts = input.Split('=');
            numberString = parts[1].Trim();
            string[] pid = numberString.Split(' ');
            List<int> pidpus = new List<int>();
            for (int i = 0; i < pid.Length; i++)
            {
                pidpus.Add(Convert.ToInt32(pid[i]));
            }
            byte[] t1 = IDEADecrypt(symmetricKey, text_byte.ToArray());
            string text = Encoding.UTF8.GetString(t1);
            byte[] hashBytes = MD5(Encoding.UTF8.GetBytes(text));
            string hash = Convert.ToBase64String(hashBytes);
            string hash2 = Convert.ToBase64String(Decrypt_RSA(pidpus, e_rsa, n));
            listBox1.Items.Add("");
            if (hash == hash2)
            {
                listBox1.Items.Add("Верифікація пройшла успішно");
                listBox1.Items.Add("Перевірка показала, що старий і новий хеші співпадають");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save File";
                saveFileDialog.FileName = "E:\\Е\\Криптология\\Kursova\\Text_result.txt";
                string filename1 = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filename1))
                {
                    writer.WriteLine(text);
                }
            }
            else
            {
                listBox1.Items.Add("Верифікація провалилася");
                listBox1.Items.Add("Перевірка показала, що старий і новий хеші не співпадають");
            } 

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_in_file();
        }

        private void btnRSA_Click(object sender, EventArgs e)
        {
            Calc();
        }

        byte[] Decrypt_RSA(List<int> t1, int e1, int n1)
        {
            byte[] m2 = new byte[t1.Count];
            int temp;
            for (int i = 0; i < t1.Count; i++)
            {
                temp = ModPow(t1[i], e1, n1);
                if(temp > 255)
                {
                    byte[] bytes = new byte[temp];
                    return bytes;
                }
                m2[i] = Convert.ToByte(temp);
            }
            return m2;
        }

        void Save_in_file()
        {
            string res1 = "";
            for (int i = 0; i < IDEA_byte.Length; i++)
            {
                if (i != IDEA_byte.Length - 1) res1 += IDEA_byte[i].ToString() + " ";
                else res1 += IDEA_byte[i].ToString();
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    writer.Dispose();
                    writer.Close();
                }
            }
            string filename = saveFileDialog.FileName;
            using (StreamWriter writer = new StreamWriter(filename))
            {
                //writer.WriteLine("Зашифрований текст = " + Idea_e);
                writer.WriteLine("Зашифрований текст у байтах = " + res1);
                writer.WriteLine("Цифровий підпис = " + Rsa_e);
            }
        }
    }
}

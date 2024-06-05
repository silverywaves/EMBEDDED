using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//추가
using System.Net.Http;
using System.Net;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer; // 타이머 객체 생성

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void conn_btn_Click(object sender, EventArgs e)
        {
            String port = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
            Console.WriteLine("PORT : " + port);
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/connection/" + port);
                request.Method = "GET";
                request.ContentType = "application/json";
                //request.Timeout = 30 * 1000;

                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("RESPONSE CODE : " + response.StatusCode);

                }

            } catch (Exception ex)
            {
                Console.WriteLine("Ex : " + ex);
            }


        }

        private void led_on_btn_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/led/1");
            request.Method = "GET";
            request.ContentType = "application/json";
            //request.Timeout = 30 * 1000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }

        private void led_off_btn_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/led/0");
            request.Method = "GET";
            request.ContentType = "application/json";
            //request.Timeout = 30 * 1000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1초마다 실행
            timer.Tick += Timer_Tick;
            timer.Start(); // 타이머 시작
        }


        private void Timer_Tick(object sender, EventArgs e) // 주기적으로 데이터를 가져와서 UI업데이트
        {
            GetTmpDataRequest();
            GetLightDataRequest();
            GetDistanceDataRequest();
        }

        private void GetTmpDataRequest()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/message/tmp"); // 서버로 request
                request.Method = "GET"; 
                request.ContentType = "application/json";  

                response = (HttpWebResponse)request.GetResponse();
                // 응답 스트림 읽기
                using (Stream responseStream = response.GetResponseStream()) 
                {
                    StreamReader reader = new StreamReader(responseStream);
                    string responseText = reader.ReadToEnd(); 
                    Console.WriteLine(responseText);
                    this.textBox3.Invoke(new Action(() => this.textBox3.Text = responseText));
                }

                // 응답 닫기
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex : " + ex);
                response.Close();
            }
        }

        private void GetLightDataRequest()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/message/light");
                request.Method = "GET";
                request.ContentType = "application/json";

                response = (HttpWebResponse)request.GetResponse();
                // 응답 스트림 읽기
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream);
                    string responseText = reader.ReadToEnd();
                    Console.WriteLine(responseText);
                    this.textBox2.Invoke(new Action(() => this.textBox2.Text = responseText));
                }

                // 응답 닫기
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex : " + ex);
            }
        }

        private void GetDistanceDataRequest()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8080/arduino/message/distance");
                request.Method = "GET";
                request.ContentType = "application/json";

                response = (HttpWebResponse)request.GetResponse();
                // 응답 스트림 읽기
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream);
                    string responseText = reader.ReadToEnd();
                    Console.WriteLine(responseText);
                    this.textBox4.Invoke(new Action(() => this.textBox4.Text = responseText));
                }

                // 응답 닫기
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex : " + ex);
            }
        }
    } 
}

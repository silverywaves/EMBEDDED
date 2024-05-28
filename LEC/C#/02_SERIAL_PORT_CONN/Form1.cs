﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // 시리얼 통신을 위한 SerialPort 객체 선언
        private SerialPort serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        // 시리얼 데이터 수신 이벤트 처리 함수
        private void SerialPort_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            // 수신된 데이터를 읽어와서 문자열로 저장
            String recvData = this.serialPort.ReadExisting();
            Console.WriteLine(recvData);

            // 데이터를 TextBox에 표시하기 위해 Invoke를 사용하여 UI 스레드에서 실행
            this.Invoke(
                // Invoke 메서드를 호출하여 메인 UI 스레드에서 실행할 작업을 지정
                // MethodInvoker 대리자를 사용하여 실행할 작업을 람다식(delegate)으로 정의
                (MethodInvoker)delegate
                {
                    this.textBox1.AppendText(recvData + "\r\n");    // UI 요소에 접근하여 텍스트를 추가
                }
            );
            // 1초 대기
            Thread.Sleep(1000);
        }

        // 연결 버튼 클릭 이벤트 핸들러
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            // 디버깅용 메시지 출력
            Console.WriteLine("연결 Btn Clicked.."); // 연결 버튼이 클릭되었음을 콘솔에 출력하는 디버깅용 메시지
            String port_number = null;  // 선택된 포트 번호를 저장할 변수를 초기화

            try {
                // 시리얼 포트가 선택되었는지 확인
                if (this.comboBox1.SelectedIndex > -1){     // 콤보박스의 기본 인덱스는 -1
                    // 선택된 포트 이름 가져오기
                    // 콤보 박스에서 선택된 포트의 이름을 가져와 port_number 변수에 저장
                    port_number = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
                    Console.WriteLine("Selected Port : " + port_number);

                    // SERIAL PORT 연결
                    this.serialPort.PortName = port_number;     // 선택된 포트로 설정
                    this.serialPort.BaudRate = 9600;            // 통신 속도를 9600으로 설정
                    this.serialPort.DataBits = 8;               // 데이터 비트를 8로 설정
                    this.serialPort.StopBits = System.IO.Ports.StopBits.One;    // 스탑 비트를 1로 설정
                    this.serialPort.Parity = System.IO.Ports.Parity.None;       // 패리티를 없음으로 설정
                    // 시리얼 포트 열기
                    this.serialPort.Open();
                    Console.WriteLine("CONNECTION SUCCESS..." + this.serialPort);
                    // 데이터 수신 이벤트 핸들러 등록
                    this.serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                }
            }
            catch(Exception ex)
            {
                // 연결 중 오류 발생 시 예외 처리
                Console.Write("CONNECTION ERROR : " + ex);
                // 시리얼 포트 닫기
                this.serialPort.Close();
            }
        }
    }
}

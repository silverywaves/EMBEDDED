using System;
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
            InitializeComponent();  // Windows Form 디자인 초기화
        }

        //시리얼 데이터 수신 이벤트 처리 함수
        private void SerialPort_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            String recvData = this.serialPort.ReadLine();    // 수신된 데이터를 읽어와서 문자열로 저장
            Console.WriteLine(recvData);    // 수신된 데이터 출력

            // LED 신호전달 문자열
            if (recvData.StartsWith("LED:"))    // 수신된 데이터가 "LED:"로 시작하는지 확인
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>  // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    // 수신된 데이터를 textBox1에 추가
                    this.textBox1.AppendText(recvData + "\r\n");    // AppendText 메서드를 사용하여 기존 텍스트 뒤에 새로운 텍스트를 추가(\r\n은 줄 바꿈)
                }));
                Thread.Sleep(10);   // 100밀리초 동안 스레드 일시 정지
            }
            // 조도센서 전달 문자열
            if (recvData.StartsWith("SUN:"))    // 수신된 데이터가 "SUN:"으로 시작하는지 확인
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>     // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    this.textBox2.Text = recvData.Replace("SUN:", "");   // 수신된 데이터에서 "SUN:"을 제거하고 나머지 부분을 textBox2의 텍스트로 설정
                }));
                Thread.Sleep(100);  // 100밀리초 동안 스레드 일시 정지
            }
            // 온도센서 전달 문자열
            if (recvData.StartsWith("TEMP:"))   // 수신된 데이터가 "TEMP:"로 시작하는지 확인
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>     // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    this.textBox3.Text = recvData.Replace("TEMP:", ""); // 수신된 데이터에서 "TEMP:"를 제거하고 나머지 부분을 textBox3의 텍스트로 설정
                }));
                Thread.Sleep(100);  // 100밀리초 동안 스레드 일시 정지
            }
            // 초음파센서 전달 문자열
            if (recvData.StartsWith("DIS:"))    // 수신된 데이터가 "DIS:"로 시작하는지 확인
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>     // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    this.textBox4.Text = recvData.Replace("DIS:", "");  // 수신된 데이터에서 "DIS:"를 제거하고 나머지 부분을 textBox4의 텍스트로 설정
                }));
                Thread.Sleep(100);  // 100밀리초 동안 스레드 일시 정지
            }

            Thread.Sleep(1000);     // 1초 대기
        }
        // 연결 버튼 클릭 이벤트 핸들러
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            // 디버깅용 메시지 출력  
            Console.WriteLine("연결 Btn Clicked..");  // 연결 버튼이 클릭되었음을 콘솔에 출력하는 디버깅용 메시지
            String port_number = null;  // 선택된 포트 번호를 저장할 변수를 초기화

            try
            {
                // 시리얼 포트가 선택되었는지 확인
                if (this.comboBox1.SelectedIndex > -1)  // 콤보박스의 기본 인덱스는 -1
                {
                    // 선택된 포트 이름 가져오기
                    // 콤보 박스에서 선택된 포트의 이름을 가져와 port_number 변수에 저장
                    port_number = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
                    Console.WriteLine("Selected Port : " + port_number);

                    //SERIAL PORT 연결
                    this.serialPort.PortName = port_number;     // 선택된 포트로 설정
                    this.serialPort.BaudRate = 9600;            // 통신 속도를 9600으로 설정
                    this.serialPort.DataBits = 8;               // 데이터 비트를 8로 설정
                    this.serialPort.StopBits = System.IO.Ports.StopBits.One;    // 스탑 비트를 1로 설정
                    this.serialPort.Parity = System.IO.Ports.Parity.None;       // 패리티를 없음으로 설정
                    // 시리얼 포트 열기
                    this.serialPort.Open();
                    Console.WriteLine("CONNECTION SUCCESS... " + this.serialPort);
                    // 데이터 수신 이벤트 핸들러 등록
                    this.serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                }

            }
            catch (Exception ex)
            {
                Console.Write("CONNECTION ERROR : " + ex);  // 연결 중 오류 발생 시 예외 처리
                this.serialPort.Close();    // 시리얼 포트 닫기
            }

        }

        // LED ON/OFF 버튼 클릭 이벤트 핸들러
        private void btn_on_Click(object sender, EventArgs e)   // LED를 켜는 버튼(btn_on)이 클릭되었을 때 호출
        // sender : 이벤트를 발생시킨 객체, EventArgs e : 이벤트에 관련된 추가 정보를 포함하는 개체
        {
            Console.WriteLine("LED ON BTN CLICKED..."); // 문자열 출력
            serialPort.Write("1");      // 문자열 1 전송(아두이노에게 LED를 켜도록 명령)
        }

        private void btn_off_Click(object sender, EventArgs e)  // LED를 끄는 버튼(btn_off)이 클릭되었을 때 호출
        {
            Console.WriteLine("LED OFF BTN CLICKED...");    // 문자열 출력
            serialPort.Write("0");          // 문자열 0 전송(아두이노에게 LED를 끄도록 명령)
        }

    }
}
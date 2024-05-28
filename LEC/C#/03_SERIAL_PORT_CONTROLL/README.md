SERIAL PORT CONTROLL
---

|form 만들기|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/0b128022-d4f3-4328-bcfd-389ef326b71e)|

<details>
<summary>[참고]form 생성 방법</summary>

### 1. 도구상자에서 그룹박스 추가
- 속성에서 Text(이름) 변경
  - 1 : Connection
  - 2 : LET
  - 3 : 조도센서
  - 4 : 온도센서
  - 5 : 초음파센서

<br>

### 2. 도구상자에서 버튼 2개 추가
- 속성에서 Text(이름) 변경
  - 1 : On
  - 2 : Off 
- 속성에서 Name(참조변수이름) 변경
  - 1 : btn_on
  - 2 : btn_off

<br>

### 3. 텍스트박스 3개를 각각 조도, 온도, 초음파센서 그룹 영역에 추가

</details>

<br>

LED ON/OFF 버튼
---
### 1. 연결

|-|
|-|
|-|

<br>

### 2. 버튼 클릭 이벤트처리
> Form1.cs
```
        private void btn_on_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LED ON BTN CLICKED...");
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LED OFF BTN CLICKED...");
        }
```

<br>

### 3. 우노 연결 후 IDE LED 켜기 실행 확인
```
const int ledPin = 10;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(ledPin,OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()){
    char inputVal = Serial.read();
    if(inputVal=='1'){
      digitalWrite(ledPin,HIGH);
      Serial.println("LED:ON");
    } else if(inputVal=='0'){
      digitalWrite(ledPin,LOW);
      Serial.println("LED:OFF");
    }
  }
}
```

<br>

### 4. IDE USB 연결 해제 후 C# 으로 신호제어 확인
```
        private void btn_on_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LED ON BTN CLICKED...");
            serialPort.Write("1");
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LED OFF BTN CLICKED...");
            serialPort.Write("0");
        }
```

<br>

### 5. 매끄럽지 않게 동작하는 부분 변경
> 현재 아두이노 모든 신호 받는 상태이므로 LED 신호 전달건만 받도록 수정
```
        //시리얼 데이터 수신 이벤트 처리 함수
        private void SerialPort_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            String recvData = this.serialPort.ReadLine();
            Console.WriteLine(recvData);

            // LED 신호전달 문자열
            if (recvData.StartsWith("LED:")) {
                // 스레드 생성 실행
                Invoke(new Action(() =>
                {
                    this.textBox1.AppendText(recvData+"\r\n");
                }));
                Thread.Sleep(10);
            }

            Thread.Sleep(1000);
        }
```

<br>

조도센서
---
### 1. 연결

|-|
|-|
|-|

<br>

### 2. ARDUINO IDE
```
// LED
const int ledPin = 10;
// 조도센서
const int sunPin = A1;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(ledPin,OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()){
    char inputVal = Serial.read();
    if(inputVal=='1'){
      digitalWrite(ledPin,HIGH);
      Serial.println("LED:ON");
    } else if(inputVal=='0'){
      digitalWrite(ledPin,LOW);
      Serial.println("LED:OFF");
    }
  }
  // 조도
  int sunValue = analogRead(A1);
  Serial.print("SUN:");
  Serial.println(sunValue);
  if(sunValue>400){
    digitalWrite(ledPin,HIGH);
    Serial.println("LED:ON");
  } else {
    digitalWrite(ledPin,LOW);
    Serial.println("LED:OFF");
  }

  delay(500);
}
```

<br>

### 3. C#
```
            // 조도센서 전달 문자열
            if (recvData.StartsWith("SUN:"))
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>
                {
                    this.textBox2.Text = recvData.Replace("SUN:","");
                }));
                Thread.Sleep(100);
            }
```

<br>

온도센서
---
### 1. 연결

|-|
|-|
|-|

<br>

### 2. ARDUINO IDE
```
float temp;

void loop() {
  // 온도
  int val = analogRead(A0);
  temp = val*0.48828125;  // 화씨->섭씨 변경
  Serial.print("TEMP:");
  Serial.println(temp);
}
```

<br>

### 3. C#
```
            // 온도센서 전달 문자열
            if (recvData.StartsWith("TEMP:"))
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>
                {
                    this.textBox3.Text = recvData.Replace("TEMP:", "");
                }));
                Thread.Sleep(100);
            }
```

<br>

초음파센서
---
### 1. 연결

|-|
|-|
|-|

<br>

### 2. ARDUINO IDE
```
// 초음파
const int trig_pin=11;
const int echo_pin=12;

void setup() {
  // 초음파
  pinMode(trig_pin,OUTPUT);
  pinMode(echo_pin,INPUT);
}

void loop() {
  // 초음파
  digitalWrite(trig_pin,LOW); // 초음파 OUT 신호 초기화
  delayMicroseconds(2);       // 2 마이크로초 동안 대기
  digitalWrite(trig_pin,HIGH);// 초음파 OUT 발사
  delayMicroseconds(10);      // 10 마이크로초 동안 대기
  digitalWrite(trig_pin,LOW); // 초음파 OUT 신호 종료

  long duration = pulseIn(echo_pin,HIGH); // 에코핀에서 초음파가 반사되어 돌아오는 시간 측정(HIGH값이 유지되는 시간을 통한 측정)
  long distance = (duration/2)/29.1;      // 측정된 이동 시간을 거리로 반환(초당 초음파의 이동 거리 : 약 29.1cm)

  Serial.print("DIS:");
  Serial.println(distance);
  if(distance<5){	// 거리가 5cm 보다 작으면
    digitalWrite(ledPin,HIGH);
    Serial.println("LED:ON");
  }
}
```
<br>

### 3. C#
```
            // 초음파센서 전달 문자열
            if (recvData.StartsWith("DIS:"))
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>
                {
                    this.textBox4.Text = recvData.Replace("DIS:", "");
                }));
                Thread.Sleep(100);
            }
```


---
#
---

<details>

<summary>전체 코드</summary>

> VS(C#)
>> Form1.cs
```
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

        //시리얼 데이터 수신[ 이벤트 처리 함수
        private void SerialPort_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            String recvData = this.serialPort.ReadLine();   // 수신된 데이터를 읽어와서 문자열로 저장
            Console.WriteLine(recvData);  // 수신된 데이터 출력

            // LED 신호전달 문자열
            if (recvData.StartsWith("LED:")) {  // 수신된 데이터가 "LED:"로 시작하는지 확인
                // 스레드 생성 실행
                Invoke(new Action(() =>    // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    // 수신된 데이터를 textBox1에 추가
                    this.textBox1.AppendText(recvData+"\r\n");  // AppendText 메서드를 사용하여 기존 텍스트 뒤에 새로운 텍스트를 추가(\r\n은 줄 바꿈)
                }));
                Thread.Sleep(100);  // 100밀리초 동안 스레드 일시 정지
            }

            // 조도센서 전달 문자열
            if (recvData.StartsWith("SUN:"))  // 수신된 데이터가 "SUN:"으로 시작하는지 확인
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>    // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    this.textBox2.Text = recvData.Replace("SUN:","");  // 수신된 데이터에서 "SUN:"을 제거하고 나머지 부분을 textBox2의 텍스트로 설정
                }));
                Thread.Sleep(100);  // 100밀리초 동안 스레드 일시 정지
            }

            // 온도센서 전달 문자열
            if (recvData.StartsWith("TEMP:"))  // 수신된 데이터가 "TEMP:"로 시작하는지 확인
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>    // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    this.textBox3.Text = recvData.Replace("TEMP:", "");  // 수신된 데이터에서 "TEMP:"를 제거하고 나머지 부분을 textBox3의 텍스트로 설정
                }));
                Thread.Sleep(100);  // 100밀리초 동안 스레드 일시 정지
            }

            // 초음파센서 전달 문자열
            if (recvData.StartsWith("DIS:"))  // 수신된 데이터가 "DIS:"로 시작하는지 확인
            {
                // 스레드 생성 실행
                Invoke(new Action(() =>    // Invoke 메서드를 사용하여 UI 요소에 접근
                {
                    this.textBox4.Text = recvData.Replace("DIS:", "");  // 수신된 데이터에서 "DIS:"를 제거하고 나머지 부분을 textBox4의 텍스트로 설정
                }));
                Thread.Sleep(100);  // 100밀리초 동안 스레드 일시 정지
            }
            Thread.Sleep(1000);  // 1초 대기
        }
        // 연결 버튼 클릭 이벤트 핸들러
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            // 디버깅용 메시지 출력
            Console.WriteLine("연결 Btn Clicked..");  // 연결 버튼이 클릭되었음을 콘솔에 출력하는 디버깅용 메시지
            String port_number = null;    // 선택된 포트 번호를 저장할 변수를 초기화
            try
            {
                // 시리얼 포트가 선택되었는지 확인
                if(this.comboBox1.SelectedIndex > -1)  // 콤보박스의 기본 인덱스는 -1
                {
                    // 선택된 포트 이름 가져오기
                    // 콤보 박스에서 선택된 포트의 이름을 가져와 port_number 변수에 저장
                    port_number = this.comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
                    Console.WriteLine("Selected Port : " + port_number);

                    //SERIAL PORT 연결
                    this.serialPort.PortName = port_number;  // 선택된 포트로 설정
                    this.serialPort.BaudRate = 9600;         // 통신 속도를 9600으로 설정
                    this.serialPort.DataBits = 8;            // 데이터 비트를 8로 설정
                    this.serialPort.StopBits = System.IO.Ports.StopBits.One;  // 스탑 비트를 1로 설정
                    this.serialPort.Parity = System.IO.Ports.Parity.None;     // 패리티를 없음으로 설정
                    // 시리얼 포트 열기
                    this.serialPort.Open();
                    Console.WriteLine("CONNECTION SUCCESS... " + this.serialPort);
                    // 데이터 수신 이벤트 핸들러 등록
                    this.serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                }
            }
            catch(Exception ex)
            {
                Console.Write("CONNECTION ERROR : " + ex);  // 연결 중 오류 발생 시 예외 처리
                this.serialPort.Close();    // 시리얼 포트 닫기
            }
        }

        // LED ON/OFF 버튼 클릭 이벤트 핸들러
        private void btn_on_Click(object sender, EventArgs e)    // LED를 켜는 버튼(btn_on)이 클릭되었을 때 호출
        // sender : 이벤트를 발생시킨 객체, EventArgs e : 이벤트에 관련된 추가 정보를 포함하는 개체
        {
            Console.WriteLine("LED ON BTN CLICKED...");  // 문자열 출력
            serialPort.Write("1");        // 문자열 1 전송(아두이노에게 LED를 켜도록 명령)
        }

        private void btn_off_Click(object sender, EventArgs e)   // LED를 끄는 버튼(btn_off)이 클릭되었을 때 호출
        {
            Console.WriteLine("LED OFF BTN CLICKED...");  // 문자열 출력
            serialPort.Write("0");        // 문자열 0 전송(아두이노에게 LED를 끄도록 명령)
        }
    }
}
```

> Arduino IDE
```
// 변수선언----------------------------------------------------
// LED
const int ledPin = 10;  // LED가 연결된 디지털 핀 번호(10)를 ledPin이라는 이름의 상수에 할당
// 조도센서
const int sunPin = A1;  // 조도 센서가 연결된 아날로그 입력 핀 번호(A1번 핀)를 sunPin이라는 이름의 상수에 할당
// 온도
float temp;             // 온도 값을 저장할 변수 선언
// 초음파
const int trig_pin=11;  // 초음파 센서의 trig핀 번호(11)를 trig_pin라는 이름의 상수에 할당
const int echo_pin=12;  // 초음파 센서의 echo핀 번호(12)를 echo_pin라는 이름의 상수에 할당
// ------------------------------------------------------------

void setup() {
  Serial.begin(9600);      // 시리얼 통신을 9600 bps의 속도로 초기화
  pinMode(ledPin,OUTPUT);  // LED 핀을 출력 모드로 설정(LED 제어)
  // 초음파
  pinMode(trig_pin,OUTPUT); // trig_pin 핀을 출력 모드로 설정(초음파 발사)
  pinMode(echo_pin,INPUT);  // echo_pin 핀을 입력 모드로 설정(초음파가 돌아오는 시간 측정)
}

void loop() {
  if(Serial.available()){            // 시리얼 입력이 있는지 확인
    char inputVal = Serial.read();   // 입력된 값을 읽어와 inputVal 변수에 저장
    if(inputVal=='1'){               // 만약 입력값이 1 이라면
      digitalWrite(ledPin,HIGH);     // 디지털 출력 설정 -> HIGH(1) = LED 켜기
      Serial.println("LED:ON");      // LED:ON 문자열 출력
    } else if(inputVal=='0'){        // 만약 입력값이 0 이라면
      digitalWrite(ledPin,LOW);      // 디지털 출력 설정 -> LOW(0) = LED 끄기
      Serial.println("LED:OFF");     // LED:OFF 문자열 출력
    }
  }
  // 조도
  int sunValue = analogRead(A1);  // analogRead 함수로 해당 아날로그 핀(A1)에 연결된 장치(조도 센서)에서 측정된 전압 값을 읽어와 sunValue 변수에 저장
  Serial.print("SUN:");           // SUN: 문자열 출력
  Serial.println(sunValue);       // 조도값 출력
  if(sunValue>500){               // 만약 조도값이 500 보다 크다면(값이 높을수록 어두움)
    digitalWrite(ledPin,HIGH);    // 디지털 출력 설정 -> HIGH(1) = LED 켜기
    Serial.println("LED:ON");     // LED:ON 문자열 출력
  } else {                        // 조도값이 500 이하라면(값이 낮을수록 밝음)
    digitalWrite(ledPin,LOW);     // 디지털 출력 설정 -> LOW(0) = LED 끄기
    Serial.println("LED:OFF");    // LED:OFF 문자열 출력
  }
  // 온도
  int val = analogRead(A0);  // analogRead 함수로 해당 아날로그 핀(A0)에 연결된 온도 센서 값을 읽어와 val 변수에 저장
  temp = val*0.48828125;     // 읽어온 값을 온도로 변환(화씨->섭씨)
  Serial.print("TEMP:");     // TEMP: 문자열 출력
  Serial.println(temp);      // 변수 temp에 저장된 온도 값을 출력
  
  // 초음파
  digitalWrite(trig_pin,LOW);  // 초음파 OUT 신호 초기화(trig_pin에 연결된 핀의 출력을 LOW(낮은 전압)으로 설정)
  delayMicroseconds(2);        // 2 마이크로초 동안 대기(초음파 모듈을 초기화한 후 일정한 시간이 지나야 안정된 송신 가능)
  digitalWrite(trig_pin,HIGH); // 초음파 OUT 발사(trig_pin에 연결된 핀의 출력을 HIGH(높은 전압)으로 설정)
  delayMicroseconds(10);       // 10 마이크로초 동안 대기(초음파가 발사된 후 일정 시간이 지나야 초음파가 돌아옴)
  digitalWrite(trig_pin,LOW);  // 초음파 OUT 신호 종료(trig_pin에 연결된 핀의 출력을 다시 LOW(낮은 전압)으로 설정)

  long duration = pulseIn(echo_pin,HIGH); // 에코핀에서 초음파가 반사되어 돌아오는 시간 측정(HIGH값이 유지되는 시간을 통한 측정)
  long distance = (duration/2)/29.1;      // 측정된 이동 시간을 거리로 반환(초당 초음파의 이동 거리 : 약 29.1cm)

  Serial.print("DIS:");         // DISL 문자열 출력
  Serial.println(distance);     // 측정된 거리 출력
  if(distance<5){               // 거리가 5cm 보다 작으면
    digitalWrite(ledPin,HIGH);  // LED 켜짐
    Serial.println("LED:ON");   // LED:ON 출력
  } 

  delay(500);    // 0.5초 대기
}
```

<br>

</details>

---

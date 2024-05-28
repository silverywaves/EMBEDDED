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
        private SerialPort serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        //시리얼 데이터 수신[ 이벤트 처리 함수
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
            Thread.Sleep(1000);
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("연결 Btn Clicked..");
            String port_number = null;
            try
            {
                if(this.comboBox1.SelectedIndex > -1)
                {
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
                    this.serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                }
            }
            catch(Exception ex)
            {
                Console.Write("CONNECTION ERROR : " + ex);
                this.serialPort.Close();
            }
        }

        private void btn_on_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LED ON BTN CLICKED...");  // 문자열 출력
            serialPort.Write("1");        // 
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            Console.WriteLine("LED OFF BTN CLICKED...");  // 문자열 출력
            serialPort.Write("0");        // 
        }
    }
}
```

> Arduino IDE
```
// LED
const int ledPin = 10;  // LED가 연결된 디지털핀 번호 선언(10번 핀)
// 조도센서
const int sunPin = A1;  // 조도 센서가 연결된 아날로그 입력핀 선언(A1번 핀)
// 온도
float temp;             // 온도를 저장할 변수 선언
// 초음파
const int trig_pin=11;  // 초음파 센서의 trig 핀 번호를 상수로 정의
const int echo_pin=12;  // 초음파 센서의 echo 핀 번호를 상수로 정의

void setup() {
  Serial.begin(9600);      // 시리얼 통신을 9600 bps의 속도로 초기화
  pinMode(ledPin,OUTPUT);  // LED 핀을 출력 모드로 설정
  // 초음파
  pinMode(trig_pin,OUTPUT); // trig_pin 핀을 출력 모드로 설정
  pinMode(echo_pin,INPUT);  // echo_pin 핀을 입력 모드로 설정
}

void loop() {
  if(Serial.available()){            // 
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
  int sunValue = analogRead(A1);  // 
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
  int val = analogRead(A0);  // A0 아날로그핀을 읽어와 val 에 저장
  temp = val*0.48828125;     // 화씨->섭씨 변경
  Serial.print("TEMP:");     // TEMP: 문자열 출력
  Serial.println(temp);      // 온도 출력
  
  // 초음파
  digitalWrite(trig_pin,LOW);  // 초음파 OUT 신호 초기화
  delayMicroseconds(2);        // 2 마이크로초 동안 대기
  digitalWrite(trig_pin,HIGH); // 초음파 OUT 발사
  delayMicroseconds(10);       // 10 마이크로초 동안 대기
  digitalWrite(trig_pin,LOW);  // 초음파 OUT 신호 종료

  long duration = pulseIn(echo_pin,HIGH); // 에코핀에서 초음파가 반사되어 돌아오는 시간 측정(HIGH값이 유지되는 시간을 통한 측정)
  long distance = (duration/2)/29.1;      // 측정된 이동 시간을 거리로 반환(초당 초음파의 이동 거리 : 약 29.1cm)

  Serial.print("DIS:");         // DISL 문자열 출력
  Serial.println(distance);     // 거리 출력
  if(distance<5){               // 거리가 5cm 보다 작으면
    digitalWrite(ledPin,HIGH);  // LED 켜짐
    Serial.println("LED:ON");   // LED:ON 출력
  } 

  delay(500);
}
```

<br>

</details>

---

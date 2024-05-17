# 아두이노 우노 실습


Arduino IDE
---
> New Sketch <br>

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/8c136c72-2f1a-445e-a7e5-a793cabf2b03)


> 사용함수 정리 <br>

|함수명|설명|
|-|-|
|Serial.begin<br>(unsigned long baudrate);|	시리얼 통신을 초기화하는 함수<br>baudrate : 통신 속도를 나타내는 매개변수, 통신할 장치 간의 데이터 전송 속도를 설정<br>주사용값 : 300, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200<br>이 값은 비트 속도 (bps, bits per second) 를 나타냄|
|pinMode<br>(pin, mode)|해당 핀의 입출력 모드 설정<br>pin은 설정하려는 핀의 번호, mode는 입력(INPUT) or 출력(OUTPUT)|
|digitalWrite(pin, value)|디지털 출력을 설정<br>pin은 출력을 설정할 핀의 번호, value는 설정할 값으로 LOW(0) or HIGH(1)|
|digitalRead(pin)|디지털 입력을 읽어옴. pin은 읽어올 핀의 번호<br>입력이 LOW(0)이면 0, HIGH(1)이면 1 반환|
|analogWrite(pin, value)|아날로그 출력 설정<br>pin은 출력을 설정할 핀의 번호, value는 설정할 값으로 0(0%)~255(100%)<br>해당 함수는 PWM (Pulse Width Modulation) 신호를 생성하여 아날로그적인 출력을 시뮬레이션|
|analogRead(pin)|아날로그 입력 값을 읽어옴.<br>pin은 읽어올 핀의 아날로그 번호(0~5)<br>반환값은 0~1023, 아날로그 입력 전압을 디지털 값으로 변환하여 제공|
|delay(milliseconds)|프로그램 실행을 지정된 밀리초(1/1000초) 동안 일시 정지<br> ex)delay(1000)은 1초 동안 프로그램 실행 정지|
|millis()|아두이노 보드가 실행된 후 경과한 밀리초 단위의 시간을 반환<br>delay() 함수 없이도 일정 시간이 경과했는지 확인하는 데 사용 가능|
|micros()|아두이노 보드가 실행된 후 경과한 마이크로초 단위의 시간을 반환<br>일정 시간이 경과했는지 확인하는 데 사용 가능|
|Serial.begin(baudrate)|시리얼 통신 초기화<br>baudrate : 통신 속도<br>이 함수를 사용하여 컴퓨터와 아두이노 간의 시리얼 통신 설정 가능|
|Serial.print(data) <br> Serial.println(data)|시리얼 모니터로 데이터를 보냄<br>data는 보낼 데이터, println()은 데이터 뒤에 줄 바꿈 문자를 추가하여 출력|


> EX <br>

```
void setup() {           // 초기설정 영역 : 한번 실행하는 함수 (초기화 함수 init)
  Serial.begin(9600);    // Serial.begin(unsigned long baudrate) : 시리얼 통신(선 통신) 초기화 함수 -=> 컴퓨터와 아두이노 간의 시리얼 통신 설정
                         // baudrate : 통신 속도(비트 속도)를 나타내는 매개변수 -> 통신할 장치 간의 데이터 전송 속도 설정
  Serial.println("SETUP FUNCTION..");    // Serial.println(data) : 시리얼 모니터로 데이터를 보냄(데이터 뒤에 줄 바꿈 문자를 추가하여 출력)
  delay(1000);          // delay(milliseconds) : 프로그램 실행을 지정된 밀리초(1/1000초)동안 일시 정지 => 1초 딜레이
}
void loop() {          // 반복설정 영역 : 무한루프
   Serial.println("[Loop] HELLOWORLD");  // Serial.println(data) : 시리얼 모니터로 데이터를 보냄(데이터 뒤에 줄 바꿈 문자를 추가하여 출력)
   delay(1000);        // delay(milliseconds) : 프로그램 실행을 지정된 밀리초(1/1000초)동안 일시 정지 => 1초 딜레이
}
```

---
#
---

LED 점등실습-01(디지털)
---
![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/9f73802b-74e7-4638-a311-51305074115c)

> ex1 DigitalWrite() <br>

```
const unsigned int pinNo = 2;

void setup()
{
   pinMode(pinNo,OUTPUT);
}

void loop()
{
	digitalWrite(pinNo, HIGH);
}
```

> ex2 DigitalWrite()<br>

```
// 전역설정 영역
const int ledPin = 13;  // LED가 연결된 디지털핀 번호 선언(13번 핀)

// 초기설정 영역 : 한번 실행하는 함수 (초기화 함수 init)
void setup() {  
  // put your setup code here, to run once:
  Serial.begin(9600);   // Serial.begin(unsigned long baudrate) : 시리얼 통신(선 통신) 초기화 함수 -=> 컴퓨터와 아두이노 간의 시리얼 통신 설정
                        // baudrate : 통신 속도(비트 속도)를 나타내는 매개변수 -> 통신할 장치 간의 데이터 전송 속도 설정
  pinMode(ledPin,OUTPUT);   // pinMode(pin, mode) : 해당 핀의 입출력 모드 설정
                            // pin = 설정하려는 핀의 번호 / mode = 입력(INPUT) 또는 출력(OUTPUT) 중 하나 기재
}

// 반복설정 영역 : 무한루프 => LED를 켜고 끄는 작업 반복
void loop() {  
  // put your main code here, to run repeatedly:
  digitalWrite(ledPin,HIGH);  // digitalWrite(pin, value) : 디지털 출력 설정 -> HIGH(1) = 켜기
                              // pin = 설정하려는 핀의 번호 / value = 설정할 값(HIGH or LOW)
  delay(1000);  // delay(milliseconds) : 프로그램 실행을 지정된 밀리초(1/1000초)동안 일시 정지 => 1초 딜레이(LED 켠 상태로 1초 대기)
  digitalWrite(ledPin,LOW);  // 디지털 출력 설정 -> LOW(0) = 끄기
  delay(1000);  // 1초 딜레이(LED 끈 상태로 1초 대기)
}
```


---
#
---

LED 점등실습-02(아날로그)
---
![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/51ff4e8c-00c6-4fbd-9215-36ca5f850dff)


```
const unsigned int AnalogPin=3;

void setup() {
  pinMode(AnalogPin,OUTPUT);
}
void loop() {
	for(int i=0;i<=255;i++)
	{
        	analogWrite(AnalogPin,i);
		delay(10);
   	}
  	//analogWrite(AnalogPin,0);
  
  	for(int i=255;i>=0;i--)
    	{
        	analogWrite(AnalogPin,i);
		delay(10);
    	}	
}
```

---
#
---

LED 점등실습-03(디지털)
---
![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/857900af-7d72-4364-94b8-eb9bdb381027)


```
const unsigned int led[5] = {2,3,4,5,6};   // 5개의 LED 핀을 나타내는 배열을 선언하고 초기화

void setup() {	// 초기설정 영역 : 한번 실행하는 함수 (초기화 함수 init과 비슷)
  for(int x=0 ; x<5 ; x++){		// x=배열의 인덱스, 반복문으로 0에서 4까지 증가
    pinMode(led[x],OUTPUT);		// led[x]에 해당하는 디지털 핀을 출력으로 설정
  }
}
	
void loop() {	// 반복 작업 설정 영역, 보드가 켜져있는 동안 계속 반복
  for(int i=0;i<5;i++){  			// i=배열의 인덱스, 반복문으로 0에서 4까지 증가 

	// 모든 LED 끄기
      for(int x=0;x<=5;x++){		// x=배열의 인덱스, 반복문으로 0에서 4까지 증가
        digitalWrite(led[x],LOW);		// 디지털 출력을 설정 : x에 해당하는 LED를 LOW로 설정하여 LED OFF
      }  

	// i번째 LED 켜기
      digitalWrite(led[i], HIGH);		// 디지털 출력을 설정 : i에 해당하는 LED를 HIGH로 설정하여 LED ON
      delay(500);				// 0.5초동안 프로그램 실행 중지(LED 켠 상태로 0.5초 대기)
  }
}
```

---
#
---

LED 점등실습-04(아날로그)
---
![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/07103b54-dd47-4dd1-9786-189b51f40a09)




> ex1 <br>

```
const unsigned int led[5] = {3,5,6,9,10};

void setup() {
  
}
void loop() {
  
	for(int i=0;i<=255;i++)
    	{
	        analogWrite(led[0],i);
		delay(5);
    	}
 	analogWrite(led[0],0);
  	for(int i=0;i<=255;i++)
    	{
        	analogWrite(led[1],i);
		delay(5);
   	 }
 	analogWrite(led[1],0);
  	for(int i=0;i<=255;i++)
    	{
		analogWrite(led[2],i);
		delay(5);
    	}
 	analogWrite(led[2],0);
  	for(int i=0;i<=255;i++)
    	{
        	analogWrite(led[3],i);
		delay(5);
    	}
 	analogWrite(led[3],0);
  	for(int i=0;i<=255;i++)
    	{
        	analogWrite(led[4],i);
		delay(5);
    	}
 	analogWrite(led[4],0);
}
```

> ex2 <br>
```
const unsigned int led[5] = {3,5,6,9,10};

void setup() {
  
}
void loop() {
  
  for(int i=0;i<5;i++)
  {
	for(int led_high=0;led_high<=255;led_high++)
    	{
        	analogWrite(led[i],led_high);
		delay(5);
    	}
 	analogWrite(led[i],0);
  }
}
```



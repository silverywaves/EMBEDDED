# 모듈 테스트

조도센서
---
> 조도센서 <br>
> 아날로그 입력 값을 읽어와 LED를 PWM으로 제어

|-|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/b5552ab9-2c01-477c-a539-3fd89f9fe07d)|
| or |
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/57f9ad21-5750-4573-bcea-8be2761a359a)|


```
const int analogPin = A0;  // 아날로그 입력 핀 번호를 상수로 정의
const int ledPin = 10;     // LED 핀 번호를 상수로 정의
void setup()
{
 Serial.begin(115200);    / 시리얼 통신을 115200 bps의 속도로 초기화
}
void loop()
{
  int analogValue = analogRead(analogPin);  // 아날로그 입력 핀에서 값 읽어오기
  
  Serial.println(analogValue);         // 읽어온 값을 시리얼 모니터에 출력
  analogWrite(ledPin, analogValue/4);  // 읽어온 값의 1/4만큼 LED를 PWM으로 ON
  delay(100);    // 일정 시간 동안 대기

}
```


---


초음파센서
---
> 초음파센서_01 <br>
> 초음파 센서를 사용하여 물체와의 거리를 측정하고, 그 값을 시리얼 모니터에 표시

|-|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/181ffed5-8976-4bd3-b730-36af810996ad)|
| or |
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/d01be1af-1a72-4b31-afb1-74fe46d56179)|


```
const int trig_pin = 11;    // 초음파 센서의 Trig 핀 번호를 상수로 정의
const int echo_pin = 12;    // 초음파 센서의 Echo 핀 번호를 상수로 정의

void setup()
{
 Serial.begin(115200);      // 시리얼 통신을 115200 bps의 속도로 초기화
 pinMode(trig_pin,OUTPUT);  // Trig 핀을 출력 모드로 설정
 pinMode(echo_pin,INPUT);   // Echo 핀을 입력 모드로 설정
}

void loop()
{
  digitalWrite(trig_pin,LOW);    // Trig 핀을 LOW로 설정
  delayMicroseconds(2);          // 일정 시간 동안 대기
  digitalWrite(trig_pin,HIGH);   // Trig 핀을 HIGH로 설정
  delayMicroseconds(10);         // 일정 시간 동안 대기
  digitalWrite(trig_pin,LOW);    // Trig 핀을 다시 LOW로 설정

  long duration = pulseIn(echo_pin,HIGH);  // Echo 핀으로부터 펄스의 길이 읽어오기
  long distance = (duration/2)/29.1;       // 펄스의 길이를 거리로 변환

  Serial.print(distance);    // 변환된 거리 값을 시리얼 모니터에 출력
  Serial.println(" cm");     // 거리 단위를 표시
  delay(100);                // 일정 시간 동안 대기
}
```

<br>

> 초음파센서_02<br>
> 초음파 센서로 측정한 거리에 따라 LED를 제어<br>
> 초음파 센서에서 응답되는 펄스의 길이를 측정하여 거리로 변환<br>
> 거리에 따라 LED ON or OFF 하도록 if-else 문을 사용<br>

|-|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/3f807cd5-cedb-44ae-8081-caf8882cb278)|
| or |
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/2de4d375-870d-4a4a-9b17-acbb916557d9)|


```
const int trig_pin = 11;    // 초음파 센서의 Trig 핀 번호를 상수로 정의
const int echo_pin = 12;    // 초음파 센서의 Echo 핀 번호를 상수로 정의

// 초음파 거리에 따라 제어할 LED 핀 번호를 변수로 선언
int LED1 = 4;       
int LED2 = 7;     
int LED3 = 8;
void setup()
{
 Serial.begin(115200);      // 시리얼 통신을 115200 bps의 속도로 초기화
 pinMode(trig_pin,OUTPUT);  // Trig 핀을 출력 모드로 설정
 pinMode(echo_pin,INPUT);   // Echo 핀을 입력 모드로 설정

  // LED 핀들을 출력 모드로 설정
  pinMode(LED1, OUTPUT);     
  pinMode(LED2, OUTPUT);
  pinMode(LED3, OUTPUT);
}

void loop()
{
  digitalWrite(trig_pin,LOW);      // Trig 핀을 LOW로 설정
  delayMicroseconds(2);            // 일정 시간 동안 대기
  digitalWrite(trig_pin,HIGH);     // Trig 핀을 HIGH로 설정
  delayMicroseconds(10);           // 일정 시간 동안 대기
  digitalWrite(trig_pin,LOW);      // Trig 핀을 다시 LOW로 설정

  long duration = pulseIn(echo_pin,HIGH);  // Echo 핀으로부터 펄스의 길이 읽어오기
  long distance = (duration/2)/29.1;       // 펄스의 길이를 거리로 변환

  Serial.print(distance);    // 변환된 거리 값을 시리얼 모니터에 출력
  Serial.println(" cm");     // 거리 단위를 표시
  delay(100);    // 일정 시간 동안 대기

  // 거리에 따라 LED 제어
  if (distance > 30)              // distance(거리) 가 30보다 크면
  {
    digitalWrite(LED1, HIGH);     // GREEN이 연결된 핀에 HIGH 신호(5V)를, → ON
    digitalWrite(LED2, LOW);      // YELLOW가 연결된 핀에 LOW 신호(0V)를, → OFF
    digitalWrite(LED3, LOW);      // RED가 연결된 핀에 LOW신호(0V)를.     → OFF
  }
  if (distance > 15 & distance <= 30)  // 거리가 15보다 크고 30보다 작은 경우
  {
    digitalWrite(LED1, LOW);     // OFF  
    digitalWrite(LED2, HIGH);    // ON
    digitalWrite(LED3, LOW);     // OFF  
  }
  if (distance > 0 & distance <= 15)   // 거리가 15 이하인 경우
  {
    digitalWrite(LED1, LOW);     // OFF  
    digitalWrite(LED2, LOW);     // OFF  
    digitalWrite(LED3, HIGH);    // ON
  }

}
```


---

온도센서
---
> 온도센서 <br>
> 아날로그 입력을 이용하여 온도를 측정하고, 그 값을 시리얼 모니터에 출력<br>

|-|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/e5504b1c-7ca9-46f7-9a10-e4d99b236d8d)|


```
float temp;      // 온도를 저장할 변수를 선언
   
void setup() {
  Serial.begin(9600);    / 시리얼 통신을 9600 bps의 속도로 초기화
}
 
void loop() {
  int val = analogRead(A0);  // 아날로그 핀에서 값 읽어오기
  temp = val*0.48828125;     // 읽어온 값으로 온도 계산 : 화씨 → 섭씨 변경
  Serial.print("Current Temperature : ");  // 시리얼 모니터에 출력할 문구를 출력
  Serial.println(temp);      // 계산된 온도를 시리얼 모니터에 출력
  delay(500);      // 0.5초 동안 대기
}

```

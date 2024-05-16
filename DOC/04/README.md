# 모듈 테스트

INPUT
---
> 입력받기 <br>

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/adf586d0-80fa-4614-b7d3-01f6ae3353f0)


```
const unsigned int led[5] = {2,3,4,5,6};  // 5개의 LED 핀을 나타내는 배열을 선언하고 초기화
void setup()
{
  Serial.begin(115200);    // 시리얼 통신 초기화(비트속도:115200bps)
}

void loop()
{
  int num=0;    // 입력된 숫자를 저장할 변수를 선언하고 초기화
  if(Serial.available()){   // 시리얼 버퍼에 데이터가 있는지 확인
   	char userInput = Serial.read();  // 시리얼로부터 데이터 읽어오기(호출 시 시리얼 버퍼의 첫 번째 바이트만 읽어옴)
   
    if (isdigit(userInput)) {  // 입력된 문자가 숫자인지 확인(userInput이 숫자일 때 true를 반환)
      num = num * 10 + (userInput - '0');  // 입력된 숫자 구성
    }
    switch(num)    // 입력된 숫자에 따라 다른 동작을 수행
    {
      case 2:		// num 값이 2 일 때
      	 digitalWrite(led[2],HIGH);  // 디지털 출력을 설정 : 2번 LED를 HIGH로 설정하여 LED ON
		 delay(10);    // LED가 켜진 상태를 일정 시간 유지
      	 break;		// 빠져나가기
      case 3:
      	 digitalWrite(led[3],HIGH);
		 delay(10);
      	 break;
      case 4:
      	 digitalWrite(led[4],HIGH);
		 delay(10);
      	 break;    
      case 5:
      	 digitalWrite(led[5],HIGH);
		 delay(10);
      	 break;      
      case 6:
      	 digitalWrite(led[6],HIGH);
		 delay(10);
      	 break;       
    }
	 digitalWrite(led[num],LOW);  // 디지털 출력을 설정 : 입력된 숫자에 해당하는 LED OFF
  }
}
```

> PUSH 버튼 <br>

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/b39926d2-d014-42d4-93b2-1c018684244e)


```
const int Pin = 2;  // 핀 번호를 상수로 정의
void setup()
{
  Serial.begin(115200);  // 시리얼 통신을 초기화
  pinMode(Pin,INPUT);    // 핀을 입력 모드로 설정
}

void loop()
{
   int val = digitalRead(Pin);   // 핀의 상태를 읽어와 변수에 저장
   Serial.println(val);          // 변수에 저장된 값을 시리얼 모니터에 출력
  
}
```

> PUSH버튼 + LED<br>

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/f12b657e-25fb-4498-be53-deeb6a1a0177)


```
const int Button = 8;  // 버튼 핀 번호를 상수로 정의
const int Led = 2;     // LED 핀 번호를 상수로 정의
void setup()
{
 
  pinMode(Button,INPUT);  // 버튼 핀을 입력 모드로 설정
  pinMode(Led,OUTPUT);    // LED 핀을 출력 모드로 설정
}

void loop()
{
  
  digitalWrite(Led,LOW);	 // LED OFF
  int val = digitalRead(Button);   // 버튼 상태를 읽어와 변수에 저장
  Serial.println(val);             // 버튼 상태를 시리얼 모니터에 출력
  if(val==HIGH)     // 만약 버튼이 눌려있다면
  {
    digitalWrite(Led,HIGH);	   // LED ON
  }
  
}
```


---

가변저항
---
> 1 가변저항_LED<br>

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/593b9de6-25a0-49d9-9457-e85b5013d278)


```
const int ledPin = 10;      // LED 핀 번호를 상수로 정의
const int analogPin = A0;   // 아날로그 입력 핀 번호를 상수로 정의

void setup()
{
  // 핀 모드 설정 등 작업 필요X → setup() 함수에서 아무 작업 수행X
}
void loop()
{
  int sensorInput = analogRead(analogPin);   // 아날로그 입력 핀에서 값 읽어오기
  Serial.println(sensorInput);               // 읽어온 값을 시리얼 모니터에 출력
  analogWrite(ledPin,sensorInput/4);         // 읽어온 값의 1/4만큼 LED를 PWM으로 ON
}
```

###### PWM(Pulse Width Modulation) : 펄스 폭 변조
- 전압 신호의 Pulse(전압 파형)을 이용하여 원하는 전압신호 평균값을 출력으로 만들어내는 것
- [참고](https://blog.naver.com/roboholic84/220333343346)


> 2 가변저항_LED<br>

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/8a6d62e3-6cda-43b8-87de-1d6bff965b48)


```
const int led[4] = {3,5,6,9};  // LED 핀 번호를 배열로 정의
const int analogPin = A0;      // 아날로그 입력 핀 번호를 상수로 정의

void setup()
{
  for(int x=0;x<4;x++){    
  	pinMode(led[x], OUTPUT);  // LED 핀을 출력 모드로 설정
  }
}

void loop()
{
 	int sensorInput = analogRead(analogPin);  // 아날로그 입력 핀에서 값 읽어오기

  // 아날로그 입력 값에 따라 LED ON or OFF
  // 입력 값이 일정 범위에 들어가면 해당 LED ON, 범위를 벗어나면 OFF
  	if(sensorInput > 1024/7*(1+0))	//146
      digitalWrite(led[0],HIGH);
  	else digitalWrite(led[0],LOW);
  	
 	if(sensorInput > 1024/7*(1+1))	//292
      digitalWrite(led[1],HIGH);
  	else digitalWrite(led[1],LOW);  
  	
  	if(sensorInput > 1024/7*(1+2))	//438
      digitalWrite(led[2],HIGH);
  	else digitalWrite(led[2],LOW);
  	
  	if(sensorInput > 1024/7*(1+3))	//584
      digitalWrite(led[3],HIGH);
  	else digitalWrite(led[3],LOW);  
  
}
```



# 모듈 테스트


능동부저
---
> 능동부저 기본 <br>

![스크린샷 2024-05-20 155841](https://github.com/silverywaves/EMBEDDED/assets/155939946/4ae57641-4887-4cdd-9e5e-72629d798ae7)


```
int buzzer = 9;                         // buzzer을 9로 설정
void setup() {
  pinMode(buzzer, OUTPUT);              // buzzer를 출력핀으로 설정
}
void loop() {
  digitalWrite(buzzer, HIGH);
  delay(1000);                              // buzzer에 1초간 HIGH를 출력
  digitalWrite(buzzer, LOW);
  delay(1000);                              // buzzer에 1초간 LOW를 출력
  digitalWrite(buzzer, HIGH);
  delay(500);                               // buzzer에 0.5초간 HIGH를 출력
  digitalWrite(buzzer, LOW);
  delay(500);                               // buzzer에 0.5초간 LOW를 출력
}
```

> 능동부저_버튼_01 <br>

![스크린샷 2024-05-20 155849](https://github.com/silverywaves/EMBEDDED/assets/155939946/f57ca903-bdb1-41c8-b5a1-73d07d2b2de9)


```
const int Pin = 2;
int buzzer = 9;

void setup() {
  Serial.begin(115200);
  pinMode(Pin,INPUT);
  pinMode(buzzer,OUTPUT);
}

void loop() {
  int val = digitalRead(Pin);
  Serial.println(val);
  if(val==HIGH)
  {
	digitalWrite(buzzer,HIGH);
	delay(100;
  }
  digitalWrite(buzzer,LOW);
}


```


---
#
---

수동부저
---

> 수동부저_버튼<br>

![스크린샷 2024-05-20 155901](https://github.com/silverywaves/EMBEDDED/assets/155939946/0cbe8ceb-ee8d-4b85-8a8a-490eeef33ba0)

수동부저 음계

![스크린샷 2024-05-20 155919](https://github.com/silverywaves/EMBEDDED/assets/155939946/84a25a7e-1569-467b-a1d4-f3309361b1c7)


```
int buzzer = 9;                                      // buzzer을 9로 설정합니다.
const int Button = 2;
const int Tones[8]={261,294,330,349,392,440,494,523};  // 도, 레, 미, 파, 솔, 라, 시,도
int current_tone = 0 ;
void setup() {
  Serial.begin(9600);
  pinMode(buzzer, OUTPUT);              // buzzer를 출력핀으로 설정합니다.
  pinMode(Button,INPUT);
}
void loop() {
   
  int val = digitalRead(Button);
  Serial.println(val);
  if(val==HIGH)
  {
     tone(buzzer,Tones[current_tone++]);
     delay(500);
     if(current_tone==8)
        current_tone=0;
  }
  noTone(buzzer);
  
}
```

> 학교종이 땡땡땡<br>

  ![스크린샷 2024-05-20 155940](https://github.com/silverywaves/EMBEDDED/assets/155939946/1aec2023-dfac-45a1-95ef-30cd866200ec)


```
#define C 262 // 도 
#define D 294 // 레 
#define E 330 // 미 
#define F 349 // 파 
#define G 392 // 솔 
#define A 440 // 라 
#define B 494 // 시 

const int Button = 2; //
int piezoPin = 9; // 부저의 ⊕극을 오렌지 보드 8번에 연결 
int tempo = 200; // duration 옵션 값 설정 
int notes[25] = { G, G, A, A, G, G, E, G, G, E, E, D, G, G, A, A, G, G, E, G, E, D, E, C }; 
void sing();
void setup() { 
  pinMode(Button,INPUT);
  pinMode (piezoPin, OUTPUT); 
} 

void loop() { 
 int val = digitalRead(Button);
  if(val==HIGH)
  {
    sing();
  }
}

void sing(){
   for (int i = 0; i < 12; i++) { 
        tone (piezoPin, notes[i], tempo); 
        delay (300); 
      } 
      delay(100); // 멜로디 중간에 짧게 멈추는 용도 

      for (int i = 12; i < 25; i++) { 
        tone (piezoPin, notes[i], tempo); 
        delay(300); 
      } 
}
```







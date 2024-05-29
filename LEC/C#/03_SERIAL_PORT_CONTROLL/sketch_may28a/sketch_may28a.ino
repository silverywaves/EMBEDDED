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
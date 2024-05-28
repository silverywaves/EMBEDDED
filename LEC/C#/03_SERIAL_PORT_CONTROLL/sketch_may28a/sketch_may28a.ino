// LED
const int ledPin = 10;
// 조도센서
const int sunPin = A1;
// 온도
float temp;
// 초음파
const int trig_pin=11;
const int echo_pin=12;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(ledPin,OUTPUT);
  // 초음파
  pinMode(trig_pin,OUTPUT);
  pinMode(echo_pin,INPUT);
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
  if(sunValue>500){
    digitalWrite(ledPin,HIGH);
    Serial.println("LED:ON");
  } else {
    digitalWrite(ledPin,LOW);
    Serial.println("LED:OFF");
  }
  // 온도
  int val = analogRead(A0);
  temp = val*0.48828125;  // 화씨->섭씨 변경
  Serial.print("TEMP:");
  Serial.println(temp);
  
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
  if(distance<5){   // 거리가 5cm 보다 작으면
    digitalWrite(ledPin,HIGH);
    Serial.println("LED:ON");
  } 

  delay(500);
}





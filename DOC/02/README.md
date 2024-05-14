# 아두이노 실습 환경 만들기

다운로드
---
> 목차 <br>

|-|-|-|-|
|-|-|-|-|
|OS|WINDOW 10|-|기본 환경|
|IDE|ARDUINO IDE|[홈페이지](https://www.arduino.cc/en/software)|아두이노 프로그램 개발에 사용되는 도구|
|API|CH340 DRIVER|[홈페이지](https://sparks.gogo.co.nz/ch340.html)|프로그램간 통신을 위해서 사용되는 도구(USB 연결 드라이버)|

---
#
---

ARDUINO IDE 설치
---
> 아두이노 IDE 설치 <br>



---
#
---

CH340 DRIVER 설치
---
> 우노 USB 인식 드라이버 <br>


---
#
---

ARDUINO 종류 
---


> TOTAL PIC <br>

|-|
|-|
|1. 우노 Uno / 2. 나노 Nano / 3. 나노 에브리 Nano Every|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/07cbe6a1-716a-4246-9e46-8d5b6ababc26)|
|4. 레오나르도 Leonardo / 5. 마이크로 Micro / 6. 101|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/677af829-1a18-407b-b093-048a3178224a)|


> TOTAL SPEC <br>

|-|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/66dc057d-cfb3-45e7-9abc-69eba1c372fb)|


> 아두이노 우노 UNO <br>

|그림|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/e51a7e58-c0fe-4e54-92d7-95500f1c24c7)|

```
- ATmega328 마이크로 컨트롤러 사용
- 아두이노의 가장 기본이 되는 제품
- 아두이노 교육용으로 가장 많이 쓰이며 초보자가 쓰기에 가장 좋은 보드
- 0~13번의 디지털 핀이 있음
- PC에서 아두이노에 스케치(프로그램)를 업로드 할 때, 시리얼 통신을 이용함
- 0, 1번 핀은 시리얼 통신의 TX, RX와 연결되어 있음(시리얼 통신할 때 사용 불가능, 실제로 거의 사용하지 않음)
- 디지털 핀 중 PWM(~로 표시, 3, 5, 6, 9, 10, 11번 핀)핀은 아날로그 신호 처럼 제어 가능
- USB 케이블에서 공급되는 5V 전압 사용, USB 없이 독립적으로 동장 또는 전력을 많이 소비하는 부품을 연결한 경우 USB 공급 전원만으로는 부족하여 외부 전원을 이용해야함
- 외부 전원은 6-20V까지 가능하지만 권장 전압은 7-12V, 12V 이상 전압 공급될 경우 보드 손상 가능성 있음
```

> 아두이노 나노 NANO <br>

|그림|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7cbd4dda-d878-40b6-886f-0374eb30088c)|
```
- 우노와 같은 ATmega328 또는 ATmega168 마이크로 컨트롤러 사용
- 크기가 작은 것이 특징임
- USB를 통해 5V 전원 공급 가능
- 정전압인 경우, 27번 5V 핀에 공급
- 정전압이 아닐 경우, 30번 Vin 핀에 공급 (6-20V까지 전원 공급 가능하지만, 7-12V 권장)
```

> 아두이노 나노 에브리 NANO EVERY <br>

|그림|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7e240c50-3f24-441c-b837-b8f44380f6c3)|
```
- 나노보다 성능이 좋은 ATmega4809 마이크로 컨트롤러 사용
- USB-Serial 통신   Atmel SAMD11D14A 칩 사용(나노: FT232 칩, 통신 속도 향상)
- 나노와 같이 크기가 작은 것이 특징임(나노는 납땜이 되어서 판매되지만 나노 에브리 모델은 직접 납땜 필요)
- Vin 전압을 5V로 바꿔주는 강압 모듈 사용(작동전압 사용 범위 넓어짐, 더 안정적)
```


> 아두이노 레오나르도 LEONARDO <br>

|그림|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7c785259-3df8-4373-bbe0-57b2115b912a)|
```
- 아두이노 우노가 USB 시리얼 통신을 위해 별도 칩을 사용하는 반면 레오나르도는 USB 기능이 내장된 ATmega32U4 마이크로 컨트롤러 사용
- ATmega32U4는 USB 통신 기능이 내장되어 있어 PC 연결시 마우스나 키보드 같은 장치로 인식시킬 수 있음
- 키보드 마우스 클래스를 이용해 입력 장치 기능하는 프로그램 제작 가능
- 입출력 핀이 많아 활용도가 높은 것이 특징
- 입출력 포트 구성이 우노와 다름
- 우노에서 사용했던 스케치(프로그램)를 레오나르도에 업로드시, "DDRx, PINx, PORTx"과 같은 입출력 직접 제어 명령 부분 주의
```

> 아두이노 마이크로 Micro  <br>

|그림|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7b7657aa-691a-411a-89f3-6a03cdcf4444)|
```
- 레오나르도와 같이 ATmega32U4 마이크로 컨트롤러 사용
- 레오나르도 동일 특징 ▽
- ATmega32U4는 USB 통신 기능이 내장되어 있어 PC 연결시 마우스나 키보드 같은 장치로 인식시킬 수 있음
- 입출력 핀이 많아 활용도가 높은 것이 특징
- 입출력 포트 구성이 우노와 다름
-  우노에서 사용했던 스케치(프로그램)를 레오나르도에 업로드시, "DDRx, PINx, PORTx"과 같은 입출력 직접 제어 명령 부분 주의
- DC 전원, 배터리 사용 가능(GND, Vin 핀)
- 자동 소프트웨어 리셋 기능, 가상 시리얼/COM  포트가 1200 보드레이트에서 열린 후 닫힐 때 리셋 발생
```

> 아두이노 101   <br>

|그림|
|-|
|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/9bee5d43-96d4-445f-a1b3-0cf342c31f84)|
```
- 초소형 저전력 모듈 Intel® Curie 마이크로 컨트롤러 사용
- 인텔 Curie는 초소형 듀얼 코어 탑재,  32bit ARC 아키텍쳐
- x86 기반 쿼크, 아톰보다 작으며 저전력 동작
- 메모리 용량, CPU 속도가 우노보다 훨씬 빠름
-  BLE(Blutooth Low Energy) 4.0, DSP 통합 센서, 6-axis 가속도 센서 내장
```


---
#
---

ARDUINO 구성품 확인
---
> - <br>

|-|-|-|-|
|-|-|-|-|
|아두이노 우노|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/b0c356b7-e629-41d8-a5dc-e39f4ed56e88)| 가장 많이 사용이 되는 아두이노로서 간편하게 처음부터 작동을 시작하고 싶을때는<br> 그림의 왼쪽 상단 빨간 버튼(Reset)을 누르면 다시 아두이노를 시작할 수 있습니다. <br>PC와는 USB로 연결을 하고, PC와의 연결은 프로그램 업로드와 5V 전원 공급을 합니다.<br> 그리고 아두이노에 기다란 핀을 꽂을 수 있는 검은색 단자가 있는데 <br>이 부분에 부품이나 핀을 연결해 부품의 특성에 맞게<br>디지털이나 아날로그 2가지 방법으로 사용을 할 수 있습니다.|-|
|디지털<br>(Digital)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/ea845d71-b9df-4ee5-b701-73b564a0c6e4)| 디지털 부분은 0 - 13번 까지 존재를 합니다.<br> 기본적으로 0과 1번은 PC와의 연결에 사용하는 것이고,<br>  실제로 사용가능한 단자는 2 - 13까지 입니다.<br>  숫자 앞에 '~' 물결 표시가 있는 것은 전원을 켜고 끄는 것을 조절할 수 있는 부분입니다.<br>  예를 들어서 전원을 반만 켜고 싶다면 ~표시가 있는 단자를 활용하여 사용할 수 있습니다. <br> 그리고 GND는 GROUND의 약자로서 기준 전압을 잡는 것을 말합니다. <br> 중학교때 땅과의 접지를 통하여 0V를 기준으로 다른 부분의 전압을 구할 수 있는 것을 알 수 있었습니다. <br> 그와 같은 개념이라고 생각하시면 될 것 같습니다. |-|
|아날로그<br>(Analog)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/a861f22e-5b45-453f-89c5-0190a9c06b80)|아날로그 부분은 A0~A5까지 있습니다.<br>디지털과 같이 값이 단순히 켜지거나 꺼진 경우 처럼 처리를 하는 것이 아니라 값들을 조절 할 수 있습니다. |-|
|파워<br>Power)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/d52899a9-7d99-4047-970b-fff3ff5879c4)|POWER 부분은 3V3은 3.3볼트 전원, 5V는 5볼트 전원을 의미합니다.<br> 3V3나 5V가 전원이 되고 이것은 +전극 부분에 해당합니다.<br> 전기는 +와 -전극이 있는데 - 전극에 해당하는 것이 GND입니다.<br>따라서 연결에 주의하여 하지 않으면 5V같은 경우에는 PC에서 아두이노를 인식하지 못하거나 부품을 망가뜨릴 수도 있습니다.|-|
|브레드 보드(Bread Board)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/e5f3a329-bc7c-4aaa-a93d-a73e861f1289)|다음 그림은 브레드 보드로서 흔히 빵판이라고 불립니다.<br>일반적으로 전기인두를 이용해서 납땜을 해야하지만 쉽게 연결하여 값들을 쉽게 확인할 수 있도록 만들어 주는 것입니다. |-|
|점퍼선(Jumper Wires)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7d8f79f7-835a-4b29-bea7-ebc3cacad3c2)|점퍼선은 보통 65개의 선으로 이루어져 65점퍼선으로 불리기도 합니다.<br>길이가 다양하고 아두이노와 브레드보드를 연결하는데 많이 사용합니다. |-|
|듀폰 케이블<br>MtoF(Male to Female)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7cb3fde5-c481-4dae-ac17-0cf00a33b4be)|듀폰 케이블 중에 핀을 꽂을 수 있는 경우로서<br> 부품의 모양이 큰 경우 자주 사용되는 케이블입니다. |-|
|듀폰 케이블<br>MtoM(Male to Male)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/305d6317-62bb-44f3-981c-40006e287579)|양쪽 모두 튀어나온 케이블로서 점퍼선과 동일한 <br>기능을 하지만 선이 깔끔하고 연결이 잘 되는 장점이 있습니다. 단점이라면 가격이 약간 비쌉니다.|-|
|아두이노 우노용 케이블|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/be1bd671-cba6-44fd-b9dc-6c78b9c163d2)|주로 아두이노 우노에 사용되는 케이블로서 'B type USB' 라고 불립니다. |-|
|LED<br>(Light Emitting Diode)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/b26c5952-de91-451a-9d90-623ffac679d4)|옆 그림은 LED로서 긴 다리가 +전극을 연결하고 짧은 다리에 -전극을 연결하면 불이 들어옵니다.<br> 크기 모양 다리의 개수에 따라서 종류도 다양합니다.<br> 그리고 LED는 외부 충격에 대해서 강한 내구성과 긴 수명을 가지고 있고,<br> 낮은 전압/ 전류로 밝은 빛을 얻을 수 있습니다.<br> 이러한 특징으로 인해서 다양한 분야에 사용이 되고 있습니다. |-|
|저항<br>(Resistance)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/f9221767-3210-4116-8fff-57726db09bd9)|저항은 말 그대로 전류가 흐르는 것에 대해서 저항한 다는 말로 전류를 줄여주기 위해서 사용합니다.<br>  이전에 5V 전류를 사용하는 것은 위험하다고 말한 적이 있습니다.<br>  그러한 경우에 저항을 사용하면 5V에 직접 연결을 하더라도 문제없이 작동을 할 수 있습니다.<br>  일반적으로 옴(Ω) 이라는 단위를 사용하고, 사용 환경에 따라 다양한 저항을 사용합니다.|-|
|버튼<br>(Button)|![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/00f4c6e3-7fde-4c14-a6a8-c420eda260c6)|스위치라고 부르는 버튼은 끊어진 두 접점을 연결하는 역할을 합니다.<br>누르면 전류가 흘러서 어떠한 기능을 할 수 있게 되고 버튼을 떼면 다시 꺼지는 그런 기능을 합니다.<br>일반적으로 브레드 보드에 4개의 다리로 연결하여 작동시키기 때문에<br>너무 많은 사용은 지양해야 할 것 같습니다.|-|


---


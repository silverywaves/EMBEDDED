# C#
C# 이란
---
- MicroSoft가 .NET 프레임워크와 함께 발표한 프로그래밍 언어
- C#이 만들어지게 된 배경 = JAVA의 등장 ⇒ 유사점多
- 객체 지향 언어
- Garbage Collector, Nullable 형식, Exception 처리, Generic, Labmda식의 개념 존재

<br>

JAVA와의 차이점
---
- 원시 타입의 차이
  - JAVA : int, boolean과 같은 기본형 타입들은 Object로부터 상속받은 참조 타입 X ⇒ 별도로 Wrapper Class의 존재 필요
  - C# : 기본형 타입도 전부 Object로부터 상속, 기본 자료형에 unsigned와 decimal 타입 추가 

<br>

.NET 프레임워크와의 관계
---
- FCL과 CLR 양쪽을 아울러 이르는 말
  - FCL(Framwork Class Library) : .NET 프레임워크를 대상으로 하는 언어들이 사용할 수 있는 Class들의 Library
  - CLR(Common Language Runtime) : 공통 언어 런타임 클래스로 가상 머신의 기능
 <br>
 
- .NET 프레임워크를 통해 가상머신의 기능을 수행함으로서 운영체제 독립성을 확보(C#으로 작성된 코드는 .NET에 의해 실행)
  - 우리가 만든 C# 코드
  - IL 언어로 컴파일 되어 .dll 확장명으로 리소스(비트맵, 문자열 등)와 함께 어셈블리에 저장
  - 프로그램 실행시에 .dll 파일은 CLR에 로드
  - CLR은 JIT(Just In Time) 컴파일을 수행하여 기계어로 번역
<br>

- 중간 언어인 IL 코드는 CTS(Change and Transport System)라는 규격 따름
  - .NET을 대상으로 하는 F#, Visual Basic, C++에서 생성된 IL 코드와 상호작용 가능
<br>

- 단일 어셈블리는 다른 언어로부터 작성된 여러 IL 코드들을 포함 가능
  - 다른 언어지만 형식은 같은 언어인 것처럼 서로 참조 가능

<br>

프로그램 구조
---
- Program
  - 하나의 서비스. 동작하게 되는 프로그램
  - 하나의 Program은 0개 이상의 Namespace로 구성
<br>

- Namspace
  - C#의 카테고리 시스템
  - Namespace의 구조가 디렉토리의 구조와 일치할 필요 X
  - Namespace에 별칭을 지정하여 사용 가능
  - 하나의 프로그램이 여러 Namespace와 매칭될 수 있음
<br>

- Type
<br>

- Member
<br>

- Assembly
  - C# 코드 파일의 컴파일의 결과물
  - 파일의 확장자 : .exe  or  .dll
  - IL 명령 형식의 실행 코드와 메타 데이터 형식의 기호 정보가 포함
    - C/C++ : 다른 파일의 코드를 참조하고 싶을 때 컴파일러에 Header 파일을 통해 "나는 이 파일의 내용을 참조하고 싶다"고 말해줘야 함
    - C# 컴파일러 : 헤더 파일이 필요 X, 다른 어셈블리를 참조하여 사용 가능

<br>

---















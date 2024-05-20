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

# Visual Studio

VS 설치 및 설정
---
### 1. [Visual Studio Tools Download](https://visualstudio.microsoft.com/ko/downloads/)

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/0c1eca74-b7c9-4d4c-87b1-69bbbfeb8cd4)

<br>

### 2. Visual Studio Installer → .NET 데스크톱 개발 선택 후 설치(수정)

![스크린샷 2024-05-20 161419](https://github.com/silverywaves/EMBEDDED/assets/155939946/1b5e7f2e-4abb-4469-a281-d87e54e9438c)


![스크린샷 2024-05-20 161436](https://github.com/silverywaves/EMBEDDED/assets/155939946/722c7a89-ea8f-471a-bb3e-a1a3913a08d8)


<br>

### 3. 실행하여 새프로젝트 생성

![스크린샷 2024-05-20 174854](https://github.com/silverywaves/EMBEDDED/assets/155939946/1c0abd4f-5e9b-4c06-a6ad-698fb9060e36)

<br>

### 4. Windows Forms 앱 선택 후 프로젝트 구성

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/a71e7ef2-b8a5-4486-8d3e-6a7dca3bfd82)

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/5df4aca9-2789-43a4-93ce-4d47f3110779)

<br>

### 5. 기본화면 설정 및 실행 확인

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/f9919ab9-3d02-4c8a-b620-03cf29b6fe38)

![스크린샷 2024-05-20 175908](https://github.com/silverywaves/EMBEDDED/assets/155939946/4f1f81fb-4cd7-4aee-bb9d-902a45053552)

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7cb03348-ec64-4695-b49a-fa5189618347)


<br>

---

애플리케이션 만들기
---
### 1. 콤보박스 추가
> 도구상자에서 ComboBox 찾아서 Form1.cs 에 Drag and Drop

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/1b8f40f4-c68f-49ef-94d4-1a4bcffa2e03)

> 콤보박스 우클릭 → 코드보기
```
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
```

> InitializeComponent() 를 Ctrl+클릭해서 comboBox부분 상세보기
```
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 32);
            this.comboBox1.TabIndex = 0;
```

<br>

### 2. Form1.cs 에서 콤보박스 우클릭 → 속성 → 데이터 카테고리의 Items 

![스크린샷 2024-05-20 181023](https://github.com/silverywaves/EMBEDDED/assets/155939946/cd90855a-cba6-4f0b-a9b0-1a9fbc842dff)

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/a018ba29-fc77-4de6-87c9-d0ff1a0cda27)

> 문자열 컬렌션 편집기
```
테스트1
테스트2
테스트3
테스트4
```

> InitializeComponent
```
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "텍스트1",
            "텍스트2",
            "텍스트3",
            "텍스트4"});
            this.comboBox1.Location = new System.Drawing.Point(60, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 32);
            this.comboBox1.TabIndex = 0;
```

<br>

### 3. 텍스트박스 2개 추가
> 한개는 우클릭 → 속성 → 동작 카테고리의 multiline : True 설정(크기 조절 및 여러 줄 생성 가능)

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/4eb95d8a-d676-437f-b3c7-f257390fd8cd)

<br>

### 4. 버튼 2개 추가
![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/32c8c9a6-2daf-438f-8362-2394e7f03599)

> InitializeComponent
```
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 52);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
```


<br>

### 5. 버튼 이름바꿔보기
> 1. InitializeComponent.cs 통해서 바꿔보기
```
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "BTN1";
            this.button1.UseVisualStyleBackColor = true;
```

> 2. 속성 통해서 바꿔보기

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/7d81dedd-ef9d-4f7d-ac9c-b9becba28066)

<br>

---

버튼 클릭 이벤트 생성
---
1.  INIT 우클릭 속성 → 콘솔애플리케이션 변경 후 저장(Ctrl+s)

![스크린샷 2024-05-20 170356](https://github.com/silverywaves/EMBEDDED/assets/155939946/0ea2a983-06eb-445b-9c53-62b37cbb43bc)

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/291a2c3d-97f2-4ec2-ae4e-fd67f7f7abe1)


<br>

2. 버튼 선택 후 속성탭에 번개모양버튼(이벤트) 클릭 → 작업 카테고리의 MouseClick 더블클릭 → 함수생성

![스크린샷 2024-05-20 170720](https://github.com/silverywaves/EMBEDDED/assets/155939946/7dc992ca-9644-4cab-987f-483cb360cca9)

![스크린샷 2024-05-20 170753](https://github.com/silverywaves/EMBEDDED/assets/155939946/2c832436-ff78-40db-b285-10f6a8ee301b)

> Form1.cs
```
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            // 콘솔에 띄울 내용 작성
            Console.WriteLine("BTN1 Clicked.. sender : " + sender);
            Console.WriteLine("BTN1 Clicked.. e : " + e);
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("BTN2 Clicked.. sender : " + sender);
            Console.WriteLine("BTN2 Clicked.. e : " + e);
        }
```

> InitializeComponent.cs
```
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "BTN1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            //
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 52);
            this.button2.TabIndex = 4;
            this.button2.Text = "BTN2";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button2_MouseClick);
```

<br>















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

# 프로젝트 vs 솔루션
> 비주얼 스튜디오를 통해 프로젝트를 생성시 솔루션 생성

![image](https://github.com/silverywaves/EMBEDDED/assets/155939946/ed014661-2356-425e-aec3-f4b6e8a2211c)


솔루션
---
- 프로젝트를 구성함에 있어 필요한 컨테이너
- 빌드정보나 비주얼 스튜디오의 설정 값 등 특 기타 파일들과 함께 하나 이상의 관련된 프로젝트들로 구성(프로젝트 묶음)
<br>

프로젝트
---
- 하나의 exe 실행파일을 생성하기 위해 포함된 모든 파일들의 묶음입
- 소스 코드, 아이콘, 이미지, 데이터 파일 등이 포함

<br>

# WINFORM 파일 구성

비주얼스튜디오로 원폼 프로젝트 생성시 Program.cs와 Form1.cs 생성(디폴트 네임)
---
> Program.cs
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIT
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());	// Form1 클래스를 객체로 생성 후 Application.Run() 안에 파라미터로 넣고 실행
        }
    }
}
```
- Application.Run()
  - Form이라는 Window 창 객체를 화면에 보여주고, 메시지를 만들어 마우스와 키보드 등의 입력 수단을 통해 UI 스레드(STAThread)에 전달
	- 기본적인 창을 출력하고 그 창에서 작동되는 마우스나 키보드의 동작을 모두 읽어와 출력하도록 만들어주는 역할

<br>

> Form1.Designer.cs
```
amespace INIT
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>

        private void InitializeComponent()
        {
	   this.SuspendLayout();
           // 
           // Form1
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(800, 450);
           this.Name = "Form1";
           this.Text = "Form1";
	   this.Load += new System.EventHandler(this.Form1_Load);
           this.ResumeLayout(false);

       }
       #endregion
}
```
- 만들고자하는 윈도우 창을 미리보기 형식으로 버튼이나 텍스트 박스 등을 설정하고 구축하는 역할(껍데기)

<br>

> Form1.cs
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
- Form1.Designer.cs에서 만들어놓은 버튼이나 텍스트박스 등을 실제로 다루는 C# 소스 코드를 작성하는 역할(실제 내용물)
- public partial class Form1 : Form
	- Form1.cs는 Form1.Designer.cs와 똑같은 클래스인데 2개의 cs 파일로 나눈 것
	- 일반적인 public class 라고 선언하지 않고 나누어 떨어진 아이들이란 말을 붙여 public partial class Form1 : Form 이라고 사용
- InitializeComponent()
	- UI를 생성하는 역할 (반드시 선언되어야 하는 존재)










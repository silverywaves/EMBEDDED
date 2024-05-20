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

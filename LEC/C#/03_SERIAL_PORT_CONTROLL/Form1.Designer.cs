namespace WindowsFormsApp1
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
        private void InitializeComponent()  // 폼 초기화시 호출 <- 폼에 포함될 콤보박스, 버튼, 레이블, 텍스트박스 등을 생성하고 설정
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();   // 콤보박스 생성 및 초기 설정
            this.button1 = new System.Windows.Forms.Button();       // 연결 버튼 생성 및 초기 설정
            this.textBox1 = new System.Windows.Forms.TextBox();     // 메시지를 표시할 레이블 생성 및 초기 설정(연결 및 LED 상태 표시)
            this.groupBox1 = new System.Windows.Forms.GroupBox();   // Connection(콤보박스+연결버튼) 그룹박스 생성 및 초기 설정
            this.groupBox2 = new System.Windows.Forms.GroupBox();   // LED(btn_on+btn_off) 그룹박스 생성 및 초기 설정
            this.btn_on = new System.Windows.Forms.Button();        // LED ON 버튼 생성 및 초기 설정
            this.btn_off = new System.Windows.Forms.Button();       // LED OFF 버튼 생성 및 초기 설정
            this.groupBox3 = new System.Windows.Forms.GroupBox();   // 조도센서(텍스트박스) 그룹박스 생성 및 초기 설정
            this.groupBox4 = new System.Windows.Forms.GroupBox();   // 온도센서(텍스트박스) 그룹박스 생성 및 초기 설정
            this.groupBox5 = new System.Windows.Forms.GroupBox();   // 초음파센서(텍스트박스) 그룹박스 생성 및 초기 설정
            this.textBox2 = new System.Windows.Forms.TextBox();     // 메시지를 표시할 레이블 생성 및 초기 설정(조도값 표시)
            this.textBox3 = new System.Windows.Forms.TextBox();     // 메시지를 표시할 레이블 생성 및 초기 설정(온도값 표시)
            this.textBox4 = new System.Windows.Forms.TextBox();     // 메시지를 표시할 레이블 생성 및 초기 설정(초음파값 표시)
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();   // 폼의 레이아웃 로직을 일시 중지하는 역할(속성을 변경하는 동안 레이아웃 업데이트 지연 -> 성능 향상)
                                    // 속성 변경 후 ResumeLayout() 호출하여 레이아웃 다시 계산
            // 중복내용 주석 생략
            // comboBox1
            // 콤보박스 항목 추가 및 위치&크기 설정
            this.comboBox1.FormattingEnabled = true;            // 콤보박스에 포맷 설정 true    
            this.comboBox1.Items.AddRange(new object[] {        // 콤보박스에 선택할 항목 추가
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.comboBox1.Location = new System.Drawing.Point(0, 34);  // 콤보박스의 위치 설정 (x: 0, y: 34)
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);   // 콤보박스의 여백 설정(모든 면(상, 하, 좌, 우)에 6픽셀의 여백을 설정)
            this.comboBox1.Name = "comboBox1";      // 콤보박스의 참조변수 이름 설정(comboBox1) 
            this.comboBox1.Size = new System.Drawing.Size(221, 32); // 콤보박스의 크기를 설정 (너비: 167, 높이: 32)
            this.comboBox1.TabIndex = 0;        // 탭 순서에서 콤보박스의 인덱스를 1로 설정
            // 
            // button1
            // 연결 버튼 설정
            this.button1.Location = new System.Drawing.Point(253, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "연결";      // 연결 버튼의 텍스트를 "연결"로 설정
            this.button1.UseVisualStyleBackColor = true;     // 연결 버튼의 기본 스타일을 사용
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick); // 연결 버튼의 클릭 이벤트 핸들러 설정
            // 
            // textBox1
            // 텍스트박스 설정
            this.textBox1.Location = new System.Drawing.Point(455, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;    // 텍스트박스가 여러 줄의 텍스트를 입력할 수 있도록 설정
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;    // 텍스트박스의 세로 스크롤바 지정
            this.textBox1.Size = new System.Drawing.Size(387, 631);
            this.textBox1.TabIndex = 2;
            // 
            // groupBox1
            // 그룹박스 설정
            this.groupBox1.Controls.Add(this.button1);      // 그룹박스에 button1 추가
            this.groupBox1.Controls.Add(this.comboBox1);    // 그룹박스에 comboBox1 추가
            this.groupBox1.Location = new System.Drawing.Point(23, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;     // Tab 키로 포커스 이동 불가
            this.groupBox1.Text = "Connection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_off);
            this.groupBox2.Controls.Add(this.btn_on);
            this.groupBox2.Location = new System.Drawing.Point(23, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 245);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LED";
            // 
            // btn_on
            // 
            this.btn_on.Location = new System.Drawing.Point(20, 60);
            this.btn_on.Name = "btn_on";
            this.btn_on.Size = new System.Drawing.Size(172, 148);
            this.btn_on.TabIndex = 5;
            this.btn_on.Text = "On";
            this.btn_on.UseVisualStyleBackColor = true;
            this.btn_on.Click += new System.EventHandler(this.btn_on_Click);
            // 
            // btn_off
            // 
            this.btn_off.Location = new System.Drawing.Point(209, 60);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(165, 147);
            this.btn_off.TabIndex = 6;
            this.btn_off.Text = "Off";
            this.btn_off.UseVisualStyleBackColor = true;
            this.btn_off.Click += new System.EventHandler(this.btn_off_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(24, 413);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 81);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "조도센서";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Location = new System.Drawing.Point(23, 500);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 81);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "온도센서";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Location = new System.Drawing.Point(23, 596);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(405, 81);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "초음파센서";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(19, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(347, 35);
            this.textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(20, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(347, 35);
            this.textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(20, 34);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(347, 35);
            this.textBox4.TabIndex = 2;
            // 
            // Form1
            // 폼의 기본 속성 설정
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);  // 폼의 크기를 조절하는데 사용되는 비율 설정
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;   // 폼이 폰트 크기 변경에 반응하도록 설정
            this.ClientSize = new System.Drawing.Size(875, 703);    // 폼의 크기 설정
            // 폼에 추가된 컨트롤 설정 ( Add : 폼에 추가 / Name : 폼의 이름 설정 / Text : 폼의 제목 설정 )
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);   // 폼의 레이아웃 로직 재시작
            this.PerformLayout();       // 필요한 경우 레이아웃을 다시 계산

        }

        #endregion
        // 폼에서 사용하는 컨트롤들 선언
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_off;
        private System.Windows.Forms.Button btn_on;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}


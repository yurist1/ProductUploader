
namespace ResizeImage
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBringPath = new System.Windows.Forms.TextBox();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.btnBringPath = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "불러 올 폴더 위치";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "저장 할 폴더 위치";
            // 
            // tbBringPath
            // 
            this.tbBringPath.Location = new System.Drawing.Point(148, 25);
            this.tbBringPath.Name = "tbBringPath";
            this.tbBringPath.Size = new System.Drawing.Size(315, 21);
            this.tbBringPath.TabIndex = 2;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Location = new System.Drawing.Point(148, 65);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(315, 21);
            this.tbSavePath.TabIndex = 3;
            // 
            // btnBringPath
            // 
            this.btnBringPath.Location = new System.Drawing.Point(491, 23);
            this.btnBringPath.Name = "btnBringPath";
            this.btnBringPath.Size = new System.Drawing.Size(75, 23);
            this.btnBringPath.TabIndex = 4;
            this.btnBringPath.Text = "폴더 열기";
            this.btnBringPath.UseVisualStyleBackColor = true;
            this.btnBringPath.Click += new System.EventHandler(this.btnBringPath_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(491, 65);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnSavePath.TabIndex = 5;
            this.btnSavePath.Text = "폴더 열기";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(606, 160);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(161, 213);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "START! ";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("굴림", 100F);
            this.lbProgress.Location = new System.Drawing.Point(155, 180);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(267, 134);
            this.lbProgress.TabIndex = 7;
            this.lbProgress.Text = "0/0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.btnBringPath);
            this.Controls.Add(this.tbSavePath);
            this.Controls.Add(this.tbBringPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBringPath;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Button btnBringPath;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbProgress;
    }
}


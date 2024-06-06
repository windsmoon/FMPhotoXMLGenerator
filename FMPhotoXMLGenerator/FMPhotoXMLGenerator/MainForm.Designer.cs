namespace FMPhotoXMLGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectFolder = new System.Windows.Forms.Button();
            this.folderPathText = new System.Windows.Forms.TextBox();
            this.isRandomPlayerCheckBox = new System.Windows.Forms.CheckBox();
            this.fromIdText = new System.Windows.Forms.TextBox();
            this.toIdText = new System.Windows.Forms.TextBox();
            this.genNewXmlButton = new System.Windows.Forms.Button();
            this.isRandomOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.fromIdLable = new System.Windows.Forms.Label();
            this.toIdLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.appendXmlButton = new System.Windows.Forms.Button();
            this.commentLabel = new System.Windows.Forms.Label();
            this.CopyFileButton = new System.Windows.Forms.Button();
            this.appendIdCommentLable = new System.Windows.Forms.Label();
            this.remappingButton = new System.Windows.Forms.Button();
            this.genXmlCommentLabel = new System.Windows.Forms.Label();
            this.remappingCommentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectFolder
            // 
            this.selectFolder.Location = new System.Drawing.Point(589, 42);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(75, 23);
            this.selectFolder.TabIndex = 0;
            this.selectFolder.Text = "选择文件夹";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // folderPathText
            // 
            this.folderPathText.Location = new System.Drawing.Point(12, 42);
            this.folderPathText.Name = "folderPathText";
            this.folderPathText.ReadOnly = true;
            this.folderPathText.Size = new System.Drawing.Size(552, 21);
            this.folderPathText.TabIndex = 1;
            this.folderPathText.TextChanged += new System.EventHandler(this.folderPathText_TextChanged);
            // 
            // isRandomPlayerCheckBox
            // 
            this.isRandomPlayerCheckBox.Location = new System.Drawing.Point(58, 69);
            this.isRandomPlayerCheckBox.Name = "isRandomPlayerCheckBox";
            this.isRandomPlayerCheckBox.Size = new System.Drawing.Size(245, 32);
            this.isRandomPlayerCheckBox.TabIndex = 2;
            this.isRandomPlayerCheckBox.Text = "球员id是否加 r- 前缀";
            this.isRandomPlayerCheckBox.UseVisualStyleBackColor = true;
            this.isRandomPlayerCheckBox.CheckedChanged += new System.EventHandler(this.isRandomPlayerCheckBox_CheckedChanged);
            // 
            // fromIdText
            // 
            this.fromIdText.Location = new System.Drawing.Point(421, 75);
            this.fromIdText.Name = "fromIdText";
            this.fromIdText.Size = new System.Drawing.Size(143, 21);
            this.fromIdText.TabIndex = 3;
            this.fromIdText.TextChanged += new System.EventHandler(this.fromIdText_TextChanged);
            // 
            // toIdText
            // 
            this.toIdText.Location = new System.Drawing.Point(421, 106);
            this.toIdText.Name = "toIdText";
            this.toIdText.Size = new System.Drawing.Size(143, 21);
            this.toIdText.TabIndex = 4;
            this.toIdText.TextChanged += new System.EventHandler(this.toIdText_TextChanged);
            // 
            // genNewXmlButton
            // 
            this.genNewXmlButton.Location = new System.Drawing.Point(46, 156);
            this.genNewXmlButton.Name = "genNewXmlButton";
            this.genNewXmlButton.Size = new System.Drawing.Size(96, 33);
            this.genNewXmlButton.TabIndex = 5;
            this.genNewXmlButton.Text = "生成 xml";
            this.genNewXmlButton.UseVisualStyleBackColor = true;
            this.genNewXmlButton.Click += new System.EventHandler(this.genNewXmlButton_Click);
            // 
            // isRandomOrderCheckBox
            // 
            this.isRandomOrderCheckBox.Location = new System.Drawing.Point(58, 107);
            this.isRandomOrderCheckBox.Name = "isRandomOrderCheckBox";
            this.isRandomOrderCheckBox.Size = new System.Drawing.Size(245, 24);
            this.isRandomOrderCheckBox.TabIndex = 6;
            this.isRandomOrderCheckBox.Text = "是否随机映射";
            this.isRandomOrderCheckBox.UseVisualStyleBackColor = true;
            this.isRandomOrderCheckBox.CheckedChanged += new System.EventHandler(this.isByFileNameOrderCheckBox_CheckedChanged);
            // 
            // fromIdLable
            // 
            this.fromIdLable.Location = new System.Drawing.Point(352, 78);
            this.fromIdLable.Name = "fromIdLable";
            this.fromIdLable.Size = new System.Drawing.Size(63, 20);
            this.fromIdLable.TabIndex = 7;
            this.fromIdLable.Text = "起始 id";
            this.fromIdLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // toIdLabel
            // 
            this.toIdLabel.Location = new System.Drawing.Point(352, 112);
            this.toIdLabel.Name = "toIdLabel";
            this.toIdLabel.Size = new System.Drawing.Size(63, 20);
            this.toIdLabel.TabIndex = 8;
            this.toIdLabel.Text = "终止 id";
            this.toIdLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(36, 408);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(675, 30);
            this.progressBar.TabIndex = 9;
            // 
            // appendXmlButton
            // 
            this.appendXmlButton.Location = new System.Drawing.Point(539, 156);
            this.appendXmlButton.Name = "appendXmlButton";
            this.appendXmlButton.Size = new System.Drawing.Size(111, 33);
            this.appendXmlButton.TabIndex = 10;
            this.appendXmlButton.Text = "追加 id";
            this.appendXmlButton.UseVisualStyleBackColor = true;
            this.appendXmlButton.Click += new System.EventHandler(this.appendXmlButton_Click);
            // 
            // commentLabel
            // 
            this.commentLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commentLabel.ForeColor = System.Drawing.Color.Red;
            this.commentLabel.Location = new System.Drawing.Point(12, 258);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(560, 113);
            this.commentLabel.TabIndex = 11;
            this.commentLabel.Text = "所有生成 xml 的操作都是在 exe 文件同级目录下生成一份 xml，以防止出错导致原来的 xml 被覆盖。\r\n\r\n可以自行复制过去或者使用 将文件复制到选定目" + "录 按钮自动复制过去，此操作会覆盖原文件。";
            // 
            // CopyFileButton
            // 
            this.CopyFileButton.Location = new System.Drawing.Point(439, 355);
            this.CopyFileButton.Name = "CopyFileButton";
            this.CopyFileButton.Size = new System.Drawing.Size(211, 36);
            this.CopyFileButton.TabIndex = 12;
            this.CopyFileButton.Text = "将文件复制到选定目录";
            this.CopyFileButton.UseVisualStyleBackColor = true;
            this.CopyFileButton.Click += new System.EventHandler(this.CopyFileButton_Click);
            // 
            // appendIdCommentLable
            // 
            this.appendIdCommentLable.Location = new System.Drawing.Point(539, 204);
            this.appendIdCommentLable.Name = "appendIdCommentLable";
            this.appendIdCommentLable.Size = new System.Drawing.Size(115, 54);
            this.appendIdCommentLable.TabIndex = 13;
            this.appendIdCommentLable.Text = "已经存在于原 xml 文件中的球员 id 不会重复追加";
            // 
            // remappingButton
            // 
            this.remappingButton.Location = new System.Drawing.Point(294, 156);
            this.remappingButton.Name = "remappingButton";
            this.remappingButton.Size = new System.Drawing.Size(107, 33);
            this.remappingButton.TabIndex = 14;
            this.remappingButton.Text = "重新映射";
            this.remappingButton.UseVisualStyleBackColor = true;
            this.remappingButton.Click += new System.EventHandler(this.remappingButton_Click);
            // 
            // genXmlCommentLabel
            // 
            this.genXmlCommentLabel.Location = new System.Drawing.Point(36, 204);
            this.genXmlCommentLabel.Name = "genXmlCommentLabel";
            this.genXmlCommentLabel.Size = new System.Drawing.Size(153, 54);
            this.genXmlCommentLabel.TabIndex = 15;
            this.genXmlCommentLabel.Text = "生成一份全新的 xml 文件";
            // 
            // remappingCommentLabel
            // 
            this.remappingCommentLabel.Location = new System.Drawing.Point(281, 204);
            this.remappingCommentLabel.Name = "remappingCommentLabel";
            this.remappingCommentLabel.Size = new System.Drawing.Size(153, 54);
            this.remappingCommentLabel.TabIndex = 16;
            this.remappingCommentLabel.Text = "将已经存在于 xml 文件中的 id 和图片名重新映射一下，如果你想重新随机一下球员头像，可以用这个";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.remappingCommentLabel);
            this.Controls.Add(this.genXmlCommentLabel);
            this.Controls.Add(this.remappingButton);
            this.Controls.Add(this.appendIdCommentLable);
            this.Controls.Add(this.CopyFileButton);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.appendXmlButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toIdLabel);
            this.Controls.Add(this.fromIdLable);
            this.Controls.Add(this.isRandomOrderCheckBox);
            this.Controls.Add(this.genNewXmlButton);
            this.Controls.Add(this.toIdText);
            this.Controls.Add(this.fromIdText);
            this.Controls.Add(this.isRandomPlayerCheckBox);
            this.Controls.Add(this.folderPathText);
            this.Controls.Add(this.selectFolder);
            this.Name = "MainForm";
            this.Text = "XML Generator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label remappingCommentLabel;

        private System.Windows.Forms.Label genXmlCommentLabel;

        private System.Windows.Forms.Button remappingButton;

        private System.Windows.Forms.Label appendIdCommentLable;

        private System.Windows.Forms.Button CopyFileButton;

        private System.Windows.Forms.Label commentLabel;

        private System.Windows.Forms.Button appendXmlButton;

        private System.Windows.Forms.ProgressBar progressBar;

        private System.Windows.Forms.Label fromIdLable;
        private System.Windows.Forms.Label toIdLabel;

        private System.Windows.Forms.CheckBox isRandomOrderCheckBox;

        private System.Windows.Forms.TextBox fromIdText;
        private System.Windows.Forms.TextBox toIdText;
        private System.Windows.Forms.Button genNewXmlButton;

        private System.Windows.Forms.CheckBox isRandomPlayerCheckBox;

        #endregion

        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.TextBox folderPathText;
    }
}
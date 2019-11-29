namespace scrcpy_ui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearchDevice = new System.Windows.Forms.Button();
            this.deviceList = new System.Windows.Forms.ListBox();
            this.btnView = new System.Windows.Forms.Button();
            // 
            // btnSearchDevice
            // 
            this.btnSearchDevice.Location = new System.Drawing.Point(666, 88);
            this.btnSearchDevice.Name = "btnSearchDevice";
            this.btnSearchDevice.Size = new System.Drawing.Size(150, 46);
            this.btnSearchDevice.TabIndex = 0;
            this.btnSearchDevice.Text = "Buscar";
            this.btnSearchDevice.UseVisualStyleBackColor = true;
            this.btnSearchDevice.Click += new System.EventHandler(this.btnSearchDevice_Click);
            // 
            // deviceList
            // 
            this.deviceList.FormattingEnabled = true;
            this.deviceList.ItemHeight = 32;
            this.deviceList.Location = new System.Drawing.Point(52, 88);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(567, 420);
            this.deviceList.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(666, 190);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(150, 46);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "Ver";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 672);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.btnSearchDevice);
            this.Name = "Form1";
            this.Text = "Form1";

        }

        #endregion

        private System.Windows.Forms.Button btnSearchDevice;
        private System.Windows.Forms.ListBox deviceList;
        private System.Windows.Forms.Button btnView;
    }
}


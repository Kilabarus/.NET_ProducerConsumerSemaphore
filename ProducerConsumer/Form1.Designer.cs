namespace ProducerConsumer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventsListTB = new System.Windows.Forms.TextBox();
            this.firstBufferContentTB = new System.Windows.Forms.TextBox();
            this.secondBufferContentTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.resultMessagesTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // eventsListTB
            // 
            this.eventsListTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.eventsListTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eventsListTB.Location = new System.Drawing.Point(18, 47);
            this.eventsListTB.Multiline = true;
            this.eventsListTB.Name = "eventsListTB";
            this.eventsListTB.ReadOnly = true;
            this.eventsListTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventsListTB.Size = new System.Drawing.Size(787, 402);
            this.eventsListTB.TabIndex = 0;
            // 
            // firstBufferContentTB
            // 
            this.firstBufferContentTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.firstBufferContentTB.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstBufferContentTB.Location = new System.Drawing.Point(18, 506);
            this.firstBufferContentTB.Multiline = true;
            this.firstBufferContentTB.Name = "firstBufferContentTB";
            this.firstBufferContentTB.ReadOnly = true;
            this.firstBufferContentTB.Size = new System.Drawing.Size(223, 364);
            this.firstBufferContentTB.TabIndex = 1;
            // 
            // secondBufferContentTB
            // 
            this.secondBufferContentTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.secondBufferContentTB.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondBufferContentTB.Location = new System.Drawing.Point(263, 506);
            this.secondBufferContentTB.Multiline = true;
            this.secondBufferContentTB.Name = "secondBufferContentTB";
            this.secondBufferContentTB.ReadOnly = true;
            this.secondBufferContentTB.Size = new System.Drawing.Size(223, 364);
            this.secondBufferContentTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "События";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "1-ый буфер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(257, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "2-ой буфер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(501, 468);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Итоговые сообщения";
            // 
            // resultMessagesTB
            // 
            this.resultMessagesTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resultMessagesTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultMessagesTB.Location = new System.Drawing.Point(507, 506);
            this.resultMessagesTB.Multiline = true;
            this.resultMessagesTB.Name = "resultMessagesTB";
            this.resultMessagesTB.ReadOnly = true;
            this.resultMessagesTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultMessagesTB.Size = new System.Drawing.Size(298, 364);
            this.resultMessagesTB.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 882);
            this.Controls.Add(this.resultMessagesTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondBufferContentTB);
            this.Controls.Add(this.firstBufferContentTB);
            this.Controls.Add(this.eventsListTB);
            this.Name = "Form1";
            this.Text = "Поставщик-потребитель";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eventsListTB;
        private System.Windows.Forms.TextBox firstBufferContentTB;
        private System.Windows.Forms.TextBox secondBufferContentTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox resultMessagesTB;
    }
}


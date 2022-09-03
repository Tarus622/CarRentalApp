namespace CarRentalApp
{
    partial class ManageRentalRecords
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
            this.label1 = new System.Windows.Forms.Label();
            this.gvRecordList = new System.Windows.Forms.DataGridView();
            this.buttonAddRecord = new System.Windows.Forms.Button();
            this.buttonEditRecord = new System.Windows.Forms.Button();
            this.buttonDeleteRecord = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage Rental Records";
            // 
            // gvRecordList
            // 
            this.gvRecordList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRecordList.Location = new System.Drawing.Point(23, 69);
            this.gvRecordList.Name = "gvRecordList";
            this.gvRecordList.RowHeadersWidth = 40;
            this.gvRecordList.RowTemplate.Height = 24;
            this.gvRecordList.Size = new System.Drawing.Size(935, 377);
            this.gvRecordList.TabIndex = 3;
            // 
            // buttonAddRecord
            // 
            this.buttonAddRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddRecord.Location = new System.Drawing.Point(23, 490);
            this.buttonAddRecord.Name = "buttonAddRecord";
            this.buttonAddRecord.Size = new System.Drawing.Size(160, 81);
            this.buttonAddRecord.TabIndex = 4;
            this.buttonAddRecord.Text = "Add Rental Record";
            this.buttonAddRecord.UseVisualStyleBackColor = true;
            this.buttonAddRecord.Click += new System.EventHandler(this.buttonAddRecord_Click);
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditRecord.Location = new System.Drawing.Point(268, 490);
            this.buttonEditRecord.Name = "buttonEditRecord";
            this.buttonEditRecord.Size = new System.Drawing.Size(160, 81);
            this.buttonEditRecord.TabIndex = 5;
            this.buttonEditRecord.Text = "Edit Rental Record";
            this.buttonEditRecord.UseVisualStyleBackColor = true;
            this.buttonEditRecord.Click += new System.EventHandler(this.buttonEditRecord_Click);
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteRecord.Location = new System.Drawing.Point(541, 490);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.Size = new System.Drawing.Size(160, 81);
            this.buttonDeleteRecord.TabIndex = 6;
            this.buttonDeleteRecord.Text = "Delete Rental Record";
            this.buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.buttonDeleteRecord.Click += new System.EventHandler(this.buttonDeleteRecord_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(798, 490);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(160, 81);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // ManageRentalRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 603);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonDeleteRecord);
            this.Controls.Add(this.buttonEditRecord);
            this.Controls.Add(this.buttonAddRecord);
            this.Controls.Add(this.gvRecordList);
            this.Controls.Add(this.label1);
            this.Name = "ManageRentalRecords";
            this.Text = "Manage Rental Records";
            this.Load += new System.EventHandler(this.ManageRentalRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvRecordList;
        private System.Windows.Forms.Button buttonAddRecord;
        private System.Windows.Forms.Button buttonEditRecord;
        private System.Windows.Forms.Button buttonDeleteRecord;
        private System.Windows.Forms.Button buttonRefresh;
    }
}
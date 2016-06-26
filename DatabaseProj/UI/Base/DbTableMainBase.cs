using DatabaseProj.Code.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.Base {
    class DbTableMainBase : DbDataShowBase {
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;

        protected CDbBaseTable hDbTable;

        public DbTableMainBase (CDbBaseTable hDbBase, string strTitle = "Table")
        {
            hDbTable = hDbBase;
            this.Text = strTitle;
        }

        private new void InitializeComponent ()
        {
            this.button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button.Location = new System.Drawing.Point( 76, 476 );
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size( 108, 36 );
            this.button.TabIndex = 3;
            this.button.Text = "添加";
            this.button.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point( 278, 476 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 105, 36 );
            this.button2.TabIndex = 4;
            this.button2.Text = "查询";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point( 461, 476 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 102, 36 );
            this.button3.TabIndex = 5;
            this.button3.Text = "刷新";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point( 661, 476 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 96, 36 );
            this.button4.TabIndex = 6;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // DbTableMainBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 9F, 18F );
            this.ClientSize = new System.Drawing.Size( 833, 571 );
            this.Controls.Add( this.button4 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button );
            this.Name = "DbTableMainBase";
            this.Controls.SetChildIndex( this.button, 0 );
            this.Controls.SetChildIndex( this.button2, 0 );
            this.Controls.SetChildIndex( this.button3, 0 );
            this.Controls.SetChildIndex( this.button4, 0 );
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }
    }
}

namespace RentaDeVideos.Mantenimientos.Login
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.picUsuario = new System.Windows.Forms.PictureBox();
            this.picContrasenia = new System.Windows.Forms.PictureBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContrasenia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(111, 100);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(127, 136);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            this.pictureLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureLogo_MouseDown);
            // 
            // picUsuario
            // 
            this.picUsuario.Image = ((System.Drawing.Image)(resources.GetObject("picUsuario.Image")));
            this.picUsuario.Location = new System.Drawing.Point(50, 258);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(36, 31);
            this.picUsuario.TabIndex = 1;
            this.picUsuario.TabStop = false;
            // 
            // picContrasenia
            // 
            this.picContrasenia.Image = ((System.Drawing.Image)(resources.GetObject("picContrasenia.Image")));
            this.picContrasenia.Location = new System.Drawing.Point(50, 321);
            this.picContrasenia.Name = "picContrasenia";
            this.picContrasenia.Size = new System.Drawing.Size(36, 36);
            this.picContrasenia.TabIndex = 2;
            this.picContrasenia.TabStop = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(111, 409);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(117, 34);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(50, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 1);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(50, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 1);
            this.panel2.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.Teal;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(92, 268);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(208, 20);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Text = "USUARIO";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.BackColor = System.Drawing.Color.Teal;
            this.txtContrasenia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasenia.ForeColor = System.Drawing.Color.White;
            this.txtContrasenia.HideSelection = false;
            this.txtContrasenia.Location = new System.Drawing.Point(92, 337);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(208, 20);
            this.txtContrasenia.TabIndex = 3;
            this.txtContrasenia.Text = "CONTRASEÑA";
            this.txtContrasenia.Enter += new System.EventHandler(this.txtContrasenia_Enter);
            this.txtContrasenia.Leave += new System.EventHandler(this.txtContrasenia_Leave);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(143, 54);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(62, 21);
            this.lblLogin.TabIndex = 10;
            this.lblLogin.Text = "LOGIN";
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(317, 11);
            this.picSalir.Margin = new System.Windows.Forms.Padding(2);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(24, 24);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSalir.TabIndex = 11;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.picSalir_Click);
            // 
            // picMinimizar
            // 
            this.picMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("picMinimizar.Image")));
            this.picMinimizar.Location = new System.Drawing.Point(276, 11);
            this.picMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(24, 24);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimizar.TabIndex = 12;
            this.picMinimizar.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(352, 496);
            this.Controls.Add(this.picMinimizar);
            this.Controls.Add(this.picSalir);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.picContrasenia);
            this.Controls.Add(this.picUsuario);
            this.Controls.Add(this.pictureLogo);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormLogin";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContrasenia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.PictureBox picContrasenia;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.PictureBox picMinimizar;
    }
}
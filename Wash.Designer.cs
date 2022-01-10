namespace RBOS
{
    partial class Wash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wash));
            this.lbVaskeTaellerPrimo = new System.Windows.Forms.Label();
            this.txtVaskeTaellerPrimo = new System.Windows.Forms.TextBox();
            this.bindingWash = new System.Windows.Forms.BindingSource(this.components);
            this.dsEOD = new RBOS.EODDataSet();
            this.lbLuxusMedLakforsegler = new System.Windows.Forms.Label();
            this.txtLuxusMedLakforsegler = new System.Windows.Forms.TextBox();
            this.lbLuksusVask = new System.Windows.Forms.Label();
            this.txtLuksusVask = new System.Windows.Forms.TextBox();
            this.lbVaskA = new System.Windows.Forms.Label();
            this.txtVaskA = new System.Windows.Forms.TextBox();
            this.lbVaskB = new System.Windows.Forms.Label();
            this.txtVaskB = new System.Windows.Forms.TextBox();
            this.lbVaskC = new System.Windows.Forms.Label();
            this.txtVaskC = new System.Windows.Forms.TextBox();
            this.lbVolumenVask = new System.Windows.Forms.Label();
            this.txtVolumenVask = new System.Windows.Forms.TextBox();
            this.lbTeknikerVask = new System.Windows.Forms.Label();
            this.txtTekniskerVask = new System.Windows.Forms.TextBox();
            this.lbTaellerUltimoBeregnet = new System.Windows.Forms.Label();
            this.txtTaellerUltimoBeregnet = new System.Windows.Forms.TextBox();
            this.lbTaellerUltimoAflaest = new System.Windows.Forms.Label();
            this.txtTaellerUltimoAflaest = new System.Windows.Forms.TextBox();
            this.lbSamletDifference = new System.Windows.Forms.Label();
            this.txtSamletDifference = new System.Windows.Forms.TextBox();
            this.lbRegDate = new System.Windows.Forms.Label();
            this.txtRegDate = new System.Windows.Forms.Label();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtVaskeTaellerPrimo2 = new System.Windows.Forms.TextBox();
            this.txtVaskeTaellerPrimo3 = new System.Windows.Forms.TextBox();
            this.txtTaellerUltimoAflaest2 = new System.Windows.Forms.TextBox();
            this.txtTaellerUltimoAflaest3 = new System.Windows.Forms.TextBox();
            this.lbVaskeTaellerPrimoDate = new System.Windows.Forms.Label();
            this.lbReadingTitle1 = new System.Windows.Forms.Label();
            this.lbReadingTitle2 = new System.Windows.Forms.Label();
            this.lbReadingTitle3 = new System.Windows.Forms.Label();
            this.adapterWash = new RBOS.EODDataSetTableAdapters.WashTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVaskeTaellerPrimo
            // 
            this.lbVaskeTaellerPrimo.AutoSize = true;
            this.lbVaskeTaellerPrimo.Location = new System.Drawing.Point(12, 66);
            this.lbVaskeTaellerPrimo.Name = "lbVaskeTaellerPrimo";
            this.lbVaskeTaellerPrimo.Size = new System.Drawing.Size(107, 13);
            this.lbVaskeTaellerPrimo.TabIndex = 3;
            this.lbVaskeTaellerPrimo.Text = "[Vaske Taeller Primo]";
            // 
            // txtVaskeTaellerPrimo
            // 
            this.txtVaskeTaellerPrimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVaskeTaellerPrimo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VaskeTaellerPrimo", true));
            this.txtVaskeTaellerPrimo.Location = new System.Drawing.Point(184, 63);
            this.txtVaskeTaellerPrimo.Name = "txtVaskeTaellerPrimo";
            this.txtVaskeTaellerPrimo.ReadOnly = true;
            this.txtVaskeTaellerPrimo.Size = new System.Drawing.Size(71, 20);
            this.txtVaskeTaellerPrimo.TabIndex = 4;
            // 
            // bindingWash
            // 
            this.bindingWash.DataMember = "Wash";
            this.bindingWash.DataSource = this.dsEOD;
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbLuxusMedLakforsegler
            // 
            this.lbLuxusMedLakforsegler.AutoSize = true;
            this.lbLuxusMedLakforsegler.Location = new System.Drawing.Point(12, 92);
            this.lbLuxusMedLakforsegler.Name = "lbLuxusMedLakforsegler";
            this.lbLuxusMedLakforsegler.Size = new System.Drawing.Size(126, 13);
            this.lbLuxusMedLakforsegler.TabIndex = 5;
            this.lbLuxusMedLakforsegler.Text = "[Luxus Med Lakforsegler]";
            // 
            // txtLuxusMedLakforsegler
            // 
            this.txtLuxusMedLakforsegler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLuxusMedLakforsegler.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "LuxusMedLakforsegler", true));
            this.txtLuxusMedLakforsegler.Location = new System.Drawing.Point(184, 89);
            this.txtLuxusMedLakforsegler.Name = "txtLuxusMedLakforsegler";
            this.txtLuxusMedLakforsegler.Size = new System.Drawing.Size(71, 20);
            this.txtLuxusMedLakforsegler.TabIndex = 6;
            // 
            // lbLuksusVask
            // 
            this.lbLuksusVask.AutoSize = true;
            this.lbLuksusVask.Location = new System.Drawing.Point(12, 118);
            this.lbLuksusVask.Name = "lbLuksusVask";
            this.lbLuksusVask.Size = new System.Drawing.Size(74, 13);
            this.lbLuksusVask.TabIndex = 7;
            this.lbLuksusVask.Text = "[Luksus Vask]";
            // 
            // txtLuksusVask
            // 
            this.txtLuksusVask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLuksusVask.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "LuksusVask", true));
            this.txtLuksusVask.Location = new System.Drawing.Point(184, 115);
            this.txtLuksusVask.Name = "txtLuksusVask";
            this.txtLuksusVask.Size = new System.Drawing.Size(71, 20);
            this.txtLuksusVask.TabIndex = 8;
            // 
            // lbVaskA
            // 
            this.lbVaskA.AutoSize = true;
            this.lbVaskA.Location = new System.Drawing.Point(12, 144);
            this.lbVaskA.Name = "lbVaskA";
            this.lbVaskA.Size = new System.Drawing.Size(47, 13);
            this.lbVaskA.TabIndex = 9;
            this.lbVaskA.Text = "[Vask A]";
            // 
            // txtVaskA
            // 
            this.txtVaskA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVaskA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VaskA", true));
            this.txtVaskA.Location = new System.Drawing.Point(184, 141);
            this.txtVaskA.Name = "txtVaskA";
            this.txtVaskA.Size = new System.Drawing.Size(71, 20);
            this.txtVaskA.TabIndex = 10;
            // 
            // lbVaskB
            // 
            this.lbVaskB.AutoSize = true;
            this.lbVaskB.Location = new System.Drawing.Point(12, 170);
            this.lbVaskB.Name = "lbVaskB";
            this.lbVaskB.Size = new System.Drawing.Size(47, 13);
            this.lbVaskB.TabIndex = 11;
            this.lbVaskB.Text = "[Vask B]";
            // 
            // txtVaskB
            // 
            this.txtVaskB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVaskB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VaskB", true));
            this.txtVaskB.Location = new System.Drawing.Point(184, 167);
            this.txtVaskB.Name = "txtVaskB";
            this.txtVaskB.Size = new System.Drawing.Size(71, 20);
            this.txtVaskB.TabIndex = 12;
            // 
            // lbVaskC
            // 
            this.lbVaskC.AutoSize = true;
            this.lbVaskC.Location = new System.Drawing.Point(12, 196);
            this.lbVaskC.Name = "lbVaskC";
            this.lbVaskC.Size = new System.Drawing.Size(47, 13);
            this.lbVaskC.TabIndex = 13;
            this.lbVaskC.Text = "[Vask C]";
            // 
            // txtVaskC
            // 
            this.txtVaskC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVaskC.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VaskC", true));
            this.txtVaskC.Location = new System.Drawing.Point(184, 193);
            this.txtVaskC.Name = "txtVaskC";
            this.txtVaskC.Size = new System.Drawing.Size(71, 20);
            this.txtVaskC.TabIndex = 14;
            // 
            // lbVolumenVask
            // 
            this.lbVolumenVask.AutoSize = true;
            this.lbVolumenVask.Location = new System.Drawing.Point(12, 222);
            this.lbVolumenVask.Name = "lbVolumenVask";
            this.lbVolumenVask.Size = new System.Drawing.Size(81, 13);
            this.lbVolumenVask.TabIndex = 15;
            this.lbVolumenVask.Text = "[Volumen Vask]";
            // 
            // txtVolumenVask
            // 
            this.txtVolumenVask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVolumenVask.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VolumenVask", true));
            this.txtVolumenVask.Location = new System.Drawing.Point(184, 219);
            this.txtVolumenVask.Name = "txtVolumenVask";
            this.txtVolumenVask.Size = new System.Drawing.Size(71, 20);
            this.txtVolumenVask.TabIndex = 16;
            // 
            // lbTeknikerVask
            // 
            this.lbTeknikerVask.AutoSize = true;
            this.lbTeknikerVask.Location = new System.Drawing.Point(12, 248);
            this.lbTeknikerVask.Name = "lbTeknikerVask";
            this.lbTeknikerVask.Size = new System.Drawing.Size(87, 13);
            this.lbTeknikerVask.TabIndex = 17;
            this.lbTeknikerVask.Text = "[Teknisker Vask]";
            // 
            // txtTekniskerVask
            // 
            this.txtTekniskerVask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTekniskerVask.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "TeknikerVask", true));
            this.txtTekniskerVask.Location = new System.Drawing.Point(184, 245);
            this.txtTekniskerVask.Name = "txtTekniskerVask";
            this.txtTekniskerVask.Size = new System.Drawing.Size(71, 20);
            this.txtTekniskerVask.TabIndex = 18;
            // 
            // lbTaellerUltimoBeregnet
            // 
            this.lbTaellerUltimoBeregnet.AutoSize = true;
            this.lbTaellerUltimoBeregnet.Location = new System.Drawing.Point(12, 274);
            this.lbTaellerUltimoBeregnet.Name = "lbTaellerUltimoBeregnet";
            this.lbTaellerUltimoBeregnet.Size = new System.Drawing.Size(123, 13);
            this.lbTaellerUltimoBeregnet.TabIndex = 19;
            this.lbTaellerUltimoBeregnet.Text = "[Taeller Ultimo Beregnet]";
            // 
            // txtTaellerUltimoBeregnet
            // 
            this.txtTaellerUltimoBeregnet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaellerUltimoBeregnet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "TaellerUltimoBeregnet", true));
            this.txtTaellerUltimoBeregnet.Location = new System.Drawing.Point(184, 271);
            this.txtTaellerUltimoBeregnet.Name = "txtTaellerUltimoBeregnet";
            this.txtTaellerUltimoBeregnet.ReadOnly = true;
            this.txtTaellerUltimoBeregnet.Size = new System.Drawing.Size(71, 20);
            this.txtTaellerUltimoBeregnet.TabIndex = 20;
            // 
            // lbTaellerUltimoAflaest
            // 
            this.lbTaellerUltimoAflaest.AutoSize = true;
            this.lbTaellerUltimoAflaest.Location = new System.Drawing.Point(12, 300);
            this.lbTaellerUltimoAflaest.Name = "lbTaellerUltimoAflaest";
            this.lbTaellerUltimoAflaest.Size = new System.Drawing.Size(112, 13);
            this.lbTaellerUltimoAflaest.TabIndex = 21;
            this.lbTaellerUltimoAflaest.Text = "[Taeller Ultimo Aflaest]";
            // 
            // txtTaellerUltimoAflaest
            // 
            this.txtTaellerUltimoAflaest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaellerUltimoAflaest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "TaellerUltimoAflaest", true));
            this.txtTaellerUltimoAflaest.Location = new System.Drawing.Point(184, 297);
            this.txtTaellerUltimoAflaest.Name = "txtTaellerUltimoAflaest";
            this.txtTaellerUltimoAflaest.Size = new System.Drawing.Size(71, 20);
            this.txtTaellerUltimoAflaest.TabIndex = 22;
            // 
            // lbSamletDifference
            // 
            this.lbSamletDifference.AutoSize = true;
            this.lbSamletDifference.Location = new System.Drawing.Point(12, 326);
            this.lbSamletDifference.Name = "lbSamletDifference";
            this.lbSamletDifference.Size = new System.Drawing.Size(97, 13);
            this.lbSamletDifference.TabIndex = 23;
            this.lbSamletDifference.Text = "[Samlet Difference]";
            // 
            // txtSamletDifference
            // 
            this.txtSamletDifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSamletDifference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "SamletDifference", true));
            this.txtSamletDifference.Location = new System.Drawing.Point(184, 323);
            this.txtSamletDifference.Name = "txtSamletDifference";
            this.txtSamletDifference.ReadOnly = true;
            this.txtSamletDifference.Size = new System.Drawing.Size(71, 20);
            this.txtSamletDifference.TabIndex = 24;
            // 
            // lbRegDate
            // 
            this.lbRegDate.AutoSize = true;
            this.lbRegDate.Location = new System.Drawing.Point(12, 38);
            this.lbRegDate.Name = "lbRegDate";
            this.lbRegDate.Size = new System.Drawing.Size(104, 13);
            this.lbRegDate.TabIndex = 25;
            this.lbRegDate.Text = "[Primo: Aflæsning pr.";
            // 
            // txtRegDate
            // 
            this.txtRegDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegDate.AutoSize = true;
            this.txtRegDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "RegDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.txtRegDate.Location = new System.Drawing.Point(181, 38);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.Size = new System.Drawing.Size(55, 13);
            this.txtRegDate.TabIndex = 26;
            this.txtRegDate.Text = "<regdate>";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(221, 366);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(98, 23);
            this.btnSaveAndClose.TabIndex = 27;
            this.btnSaveAndClose.Text = "[Gem && luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(325, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "[Annuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtVaskeTaellerPrimo2
            // 
            this.txtVaskeTaellerPrimo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVaskeTaellerPrimo2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VaskeTaellerPrimo2", true));
            this.txtVaskeTaellerPrimo2.Location = new System.Drawing.Point(261, 63);
            this.txtVaskeTaellerPrimo2.Name = "txtVaskeTaellerPrimo2";
            this.txtVaskeTaellerPrimo2.ReadOnly = true;
            this.txtVaskeTaellerPrimo2.Size = new System.Drawing.Size(71, 20);
            this.txtVaskeTaellerPrimo2.TabIndex = 29;
            // 
            // txtVaskeTaellerPrimo3
            // 
            this.txtVaskeTaellerPrimo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVaskeTaellerPrimo3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VaskeTaellerPrimo3", true));
            this.txtVaskeTaellerPrimo3.Location = new System.Drawing.Point(338, 63);
            this.txtVaskeTaellerPrimo3.Name = "txtVaskeTaellerPrimo3";
            this.txtVaskeTaellerPrimo3.ReadOnly = true;
            this.txtVaskeTaellerPrimo3.Size = new System.Drawing.Size(71, 20);
            this.txtVaskeTaellerPrimo3.TabIndex = 30;
            // 
            // txtTaellerUltimoAflaest2
            // 
            this.txtTaellerUltimoAflaest2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaellerUltimoAflaest2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "TaellerUltimoAflaest2", true));
            this.txtTaellerUltimoAflaest2.Location = new System.Drawing.Point(261, 297);
            this.txtTaellerUltimoAflaest2.Name = "txtTaellerUltimoAflaest2";
            this.txtTaellerUltimoAflaest2.ReadOnly = true;
            this.txtTaellerUltimoAflaest2.Size = new System.Drawing.Size(71, 20);
            this.txtTaellerUltimoAflaest2.TabIndex = 31;
            // 
            // txtTaellerUltimoAflaest3
            // 
            this.txtTaellerUltimoAflaest3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaellerUltimoAflaest3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "TaellerUltimoAflaest3", true));
            this.txtTaellerUltimoAflaest3.Location = new System.Drawing.Point(338, 297);
            this.txtTaellerUltimoAflaest3.Name = "txtTaellerUltimoAflaest3";
            this.txtTaellerUltimoAflaest3.ReadOnly = true;
            this.txtTaellerUltimoAflaest3.Size = new System.Drawing.Size(71, 20);
            this.txtTaellerUltimoAflaest3.TabIndex = 32;
            // 
            // lbVaskeTaellerPrimoDate
            // 
            this.lbVaskeTaellerPrimoDate.AutoSize = true;
            this.lbVaskeTaellerPrimoDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWash, "VaskeTaellerPrimoDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.lbVaskeTaellerPrimoDate.Location = new System.Drawing.Point(111, 66);
            this.lbVaskeTaellerPrimoDate.Name = "lbVaskeTaellerPrimoDate";
            this.lbVaskeTaellerPrimoDate.Size = new System.Drawing.Size(40, 13);
            this.lbVaskeTaellerPrimoDate.TabIndex = 33;
            this.lbVaskeTaellerPrimoDate.Text = "<date>";
            // 
            // lbReadingTitle1
            // 
            this.lbReadingTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReadingTitle1.AutoSize = true;
            this.lbReadingTitle1.Location = new System.Drawing.Point(181, 9);
            this.lbReadingTitle1.Name = "lbReadingTitle1";
            this.lbReadingTitle1.Size = new System.Drawing.Size(65, 13);
            this.lbReadingTitle1.TabIndex = 34;
            this.lbReadingTitle1.Text = "[Afstemning]";
            // 
            // lbReadingTitle2
            // 
            this.lbReadingTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReadingTitle2.AutoSize = true;
            this.lbReadingTitle2.Location = new System.Drawing.Point(258, 9);
            this.lbReadingTitle2.Name = "lbReadingTitle2";
            this.lbReadingTitle2.Size = new System.Drawing.Size(74, 13);
            this.lbReadingTitle2.TabIndex = 35;
            this.lbReadingTitle2.Text = "[Afstemning 2]";
            // 
            // lbReadingTitle3
            // 
            this.lbReadingTitle3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReadingTitle3.AutoSize = true;
            this.lbReadingTitle3.Location = new System.Drawing.Point(335, 9);
            this.lbReadingTitle3.Name = "lbReadingTitle3";
            this.lbReadingTitle3.Size = new System.Drawing.Size(74, 13);
            this.lbReadingTitle3.TabIndex = 36;
            this.lbReadingTitle3.Text = "[Afstemning 3]";
            // 
            // adapterWash
            // 
            this.adapterWash.ClearBeforeFill = true;
            // 
            // Wash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 401);
            this.Controls.Add(this.lbReadingTitle3);
            this.Controls.Add(this.lbReadingTitle2);
            this.Controls.Add(this.lbReadingTitle1);
            this.Controls.Add(this.lbVaskeTaellerPrimoDate);
            this.Controls.Add(this.txtTaellerUltimoAflaest3);
            this.Controls.Add(this.txtTaellerUltimoAflaest2);
            this.Controls.Add(this.txtVaskeTaellerPrimo3);
            this.Controls.Add(this.txtVaskeTaellerPrimo2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.txtRegDate);
            this.Controls.Add(this.lbRegDate);
            this.Controls.Add(this.lbVaskeTaellerPrimo);
            this.Controls.Add(this.txtVaskeTaellerPrimo);
            this.Controls.Add(this.lbLuxusMedLakforsegler);
            this.Controls.Add(this.txtLuxusMedLakforsegler);
            this.Controls.Add(this.lbLuksusVask);
            this.Controls.Add(this.txtLuksusVask);
            this.Controls.Add(this.lbVaskA);
            this.Controls.Add(this.txtVaskA);
            this.Controls.Add(this.lbVaskB);
            this.Controls.Add(this.txtVaskB);
            this.Controls.Add(this.lbVaskC);
            this.Controls.Add(this.txtVaskC);
            this.Controls.Add(this.lbVolumenVask);
            this.Controls.Add(this.txtVolumenVask);
            this.Controls.Add(this.lbTeknikerVask);
            this.Controls.Add(this.txtTekniskerVask);
            this.Controls.Add(this.lbTaellerUltimoBeregnet);
            this.Controls.Add(this.txtTaellerUltimoBeregnet);
            this.Controls.Add(this.lbTaellerUltimoAflaest);
            this.Controls.Add(this.txtTaellerUltimoAflaest);
            this.Controls.Add(this.lbSamletDifference);
            this.Controls.Add(this.txtSamletDifference);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Wash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Vask afstemning]";
            ((System.ComponentModel.ISupportInitialize)(this.bindingWash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EODDataSet dsEOD;
        private System.Windows.Forms.BindingSource bindingWash;
        private RBOS.EODDataSetTableAdapters.WashTableAdapter adapterWash;
        private System.Windows.Forms.TextBox txtVaskeTaellerPrimo;
        private System.Windows.Forms.TextBox txtLuxusMedLakforsegler;
        private System.Windows.Forms.TextBox txtLuksusVask;
        private System.Windows.Forms.TextBox txtVaskA;
        private System.Windows.Forms.TextBox txtVaskB;
        private System.Windows.Forms.TextBox txtVaskC;
        private System.Windows.Forms.TextBox txtVolumenVask;
        private System.Windows.Forms.TextBox txtTekniskerVask;
        private System.Windows.Forms.TextBox txtTaellerUltimoBeregnet;
        private System.Windows.Forms.TextBox txtTaellerUltimoAflaest;
        private System.Windows.Forms.TextBox txtSamletDifference;
        private System.Windows.Forms.Label lbVaskeTaellerPrimo;
        private System.Windows.Forms.Label lbLuxusMedLakforsegler;
        private System.Windows.Forms.Label lbLuksusVask;
        private System.Windows.Forms.Label lbVaskA;
        private System.Windows.Forms.Label lbVaskB;
        private System.Windows.Forms.Label lbVaskC;
        private System.Windows.Forms.Label lbVolumenVask;
        private System.Windows.Forms.Label lbTeknikerVask;
        private System.Windows.Forms.Label lbTaellerUltimoBeregnet;
        private System.Windows.Forms.Label lbTaellerUltimoAflaest;
        private System.Windows.Forms.Label lbSamletDifference;
        private System.Windows.Forms.Label lbRegDate;
        private System.Windows.Forms.Label txtRegDate;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtVaskeTaellerPrimo2;
        private System.Windows.Forms.TextBox txtVaskeTaellerPrimo3;
        private System.Windows.Forms.TextBox txtTaellerUltimoAflaest2;
        private System.Windows.Forms.TextBox txtTaellerUltimoAflaest3;
        private System.Windows.Forms.Label lbVaskeTaellerPrimoDate;
        private System.Windows.Forms.Label lbReadingTitle1;
        private System.Windows.Forms.Label lbReadingTitle2;
        private System.Windows.Forms.Label lbReadingTitle3;
    }
}
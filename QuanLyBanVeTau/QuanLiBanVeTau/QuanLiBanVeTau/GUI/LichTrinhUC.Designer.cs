namespace QuanLiBanVeTau.GUI
{
    partial class LichTrinhUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gCtrlLichTrinh = new DevExpress.XtraGrid.GridControl();
            this.gVLichTrinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lUEGaDi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lUEGaDen = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDatVe = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrlLichTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVLichTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUEGaDi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUEGaDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDatVe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gCtrlLichTrinh
            // 
            this.gCtrlLichTrinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrlLichTrinh.Location = new System.Drawing.Point(2, 21);
            this.gCtrlLichTrinh.MainView = this.gVLichTrinh;
            this.gCtrlLichTrinh.Name = "gCtrlLichTrinh";
            this.gCtrlLichTrinh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDatVe,
            this.lUEGaDi,
            this.lUEGaDen});
            this.gCtrlLichTrinh.Size = new System.Drawing.Size(862, 445);
            this.gCtrlLichTrinh.TabIndex = 1;
            this.gCtrlLichTrinh.UseEmbeddedNavigator = true;
            this.gCtrlLichTrinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gVLichTrinh,
            this.gridView1});
            this.gCtrlLichTrinh.Load += new System.EventHandler(this.gCtrlLichTrinh_Load);
            // 
            // gVLichTrinh
            // 
            this.gVLichTrinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gVLichTrinh.GridControl = this.gCtrlLichTrinh;
            this.gVLichTrinh.Name = "gVLichTrinh";
            this.gVLichTrinh.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Mã lịch trình";
            this.gridColumn10.FieldName = "MaLichTrinh";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ga đi";
            this.gridColumn1.ColumnEdit = this.lUEGaDi;
            this.gridColumn1.FieldName = "MaGaDi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 93;
            // 
            // lUEGaDi
            // 
            this.lUEGaDi.AutoHeight = false;
            this.lUEGaDi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lUEGaDi.DisplayMember = "TenGa";
            this.lUEGaDi.Name = "lUEGaDi";
            this.lUEGaDi.ValueMember = "MaGa";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ga đến";
            this.gridColumn2.ColumnEdit = this.lUEGaDen;
            this.gridColumn2.FieldName = "MaGaDen";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 93;
            // 
            // lUEGaDen
            // 
            this.lUEGaDen.AutoHeight = false;
            this.lUEGaDen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lUEGaDen.DisplayMember = "TenGa";
            this.lUEGaDen.Name = "lUEGaDen";
            this.lUEGaDen.ValueMember = "MaGa";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mã tàu";
            this.gridColumn3.FieldName = "MaTau";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 93;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ngày khởi hành";
            this.gridColumn4.FieldName = "NgayKhoiHanh";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 103;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Giờ khởi hành";
            this.gridColumn5.DisplayFormat.FormatString = "hh:mm tt";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "NgayKhoiHanh";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 105;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ngày đến";
            this.gridColumn6.FieldName = "NgayDen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 110;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Giờ đến";
            this.gridColumn7.DisplayFormat.FormatString = "hh:mm tt";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "NgayDen";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 89;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Số chỗ trống";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 105;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Đặt vé";
            this.gridColumn9.ColumnEdit = this.btnDatVe;
            this.gridColumn9.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 53;
            // 
            // btnDatVe
            // 
            this.btnDatVe.AutoHeight = false;
            this.btnDatVe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::QuanLiBanVeTau.Properties.Resources.create_ticket_icon16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btnDatVe.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDatVe.Name = "btnDatVe";
            this.btnDatVe.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDatVe.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnDatVe_ButtonClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gCtrlLichTrinh;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gCtrlLichTrinh);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(866, 468);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Thông tin các chuyến tàu";
            // 
            // LichTrinhUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "LichTrinhUC";
            this.Size = new System.Drawing.Size(866, 468);
            ((System.ComponentModel.ISupportInitialize)(this.gCtrlLichTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVLichTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUEGaDi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUEGaDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDatVe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDatVe;
        public DevExpress.XtraGrid.GridControl gCtrlLichTrinh;
        public DevExpress.XtraGrid.Views.Grid.GridView gVLichTrinh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lUEGaDi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lUEGaDen;
 
    }
}

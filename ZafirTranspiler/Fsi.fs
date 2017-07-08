    type TargetField =
         | CURR_ASSIGNED_VEND
         | ORIG_ASSIGNED_VEND
         | ORIG_INV_NUM
         | POST_DTE_KEY
         | RECEIVABLE_CURR_BILLING_TO_DTE
         | RECEIVABLE_CURR_DELINQ_DTE
         | RECEIVABLE_CURR_DUE_DTE
         | RECEIVABLE_CURR_ISSUE_DTE
         | RECEIVABLE_CURR_TO_DTE
         | RECEIVABLE_KEY
         | RECEIVABLE_ORIG_BILLING_TO_DTE
         | RECEIVABLE_ORIG_DELINQ_DTE
         | RECEIVABLE_ORIG_DUE_DTE
         | RECEIVABLE_ORIG_ISSUE_DTE
         | RECEIVABLE_ORIG_TO_DTE
         | TRANS_DTE_KEY
         | VERS_BEG_DTE  
         | VERS_END_DTE 
         | CURR_VERS_FLAG
         | ITEM_KEY
         | INCDT_KEY
         | CUST_KEY
         | CARRIER_KEY
         | CARRIER_PROCEDURE_KEY
         | COLL_PERSON_KEY
         | EMP_KEY
         | FIN_TRANS_TYPE_KEY
         | DTE_KEY
         | COH_ORG_KEY
         | SYS_LOAD_KEY       
         | ORIG_CUST_KEY      
         | COLL_VEND_CONTR_KEY
         | GL_COMBO_KEY 
         | GL_ACCT_ID
         | FUND_ID
         | FUND_CNTR_ID
         | FUNC_AREA_ID
         | ROW_CHG_RSN
         | Nil
    
    type FinTransViewField =
         | INTRA_DAY_ORDER
         | DEPT_LONG_NAME
         | CONTR_ID
         | CUST_PAR_ID
         | CUST_PAR_NAME
         | ADJ_FLAG
         | ALLOC_TRANS_FLAG
         | BILLED_FLAG
         | BLK_NUM
         | BOOT_SERIAL_NUM
         | BUS_AREA_ID
         | BUS_CONT_PERSON_NAME
         | CARRIER_FIN_CLASS
         | CARRIER_FIN_GRP
         | CARRIER_GRP
         | CARRIER_NAME
         | CARRIER_PROCEDURE_BILL_CODE
         | CARRIER_PROCEDURE_CODE
         | CARRIER_PROCEDURE_DESCR
         | CARRIER_PROCEDURE_SRC
         | CARRIER_PROCEDURE_TYPE
         | CARRIER_SRC
         | COH_EMP_NUM
         | COLL_PERSON_ID
         | COLL_PERSON_NAME
         | COLL_PERSON_TYPE
         | CONFI_CUST_FLAG
         | CUST_ADDR_LINE_1
         | CUST_ADDR_LINE_2
         | CUST_ADDR_LINE_3
         | CUST_APT_LOT
         | CUST_CITY
         | CUST_CNTY
         | CUST_CTRY
         | CUST_EMAIL_ADDR
         | CUST_FAX_NUM
         | CUST_GIS_CITY
         | CUST_GIS_LOCATR_NAME
         | CUST_GIS_MATCH_SCORE
         | CUST_GIS_PREFIX
         | CUST_GIS_ST_NAME
         | CUST_GIS_ST_NUM
         | CUST_GIS_ST_PRETYPE
         | CUST_GIS_ST_TYPE
         | CUST_GIS_SUFF
         | CUST_GIS_X
         | CUST_GIS_Y
         | CUST_GIS_ZIP
         | CUST_ID
         | CUST_IN_CITY_FLAG
         | CUST_IS_VEND_FLAG
         | CUST_NAME
         | CUST_PAR_KEY
         | CUST_PHN_NUM_1
         | CUST_PHN_NUM_2
         | CUST_PHN_NUM_3
         | CUST_PREFIX
         | CUST_SERV_LVL
         | CUST_ST
         | CUST_STATE
         | CUST_ST_DIR
         | CUST_ST_NAME
         | CUST_ST_NUM
         | CUST_ST_PRETYPE
         | CUST_ST_TYPE
         | CUST_SUFF
         | CUST_TYPE
         | CUST_ZIP_CODE
         | CUST_ZIP_PLUS_4
         | DEC_CUST_FLAG
         | DERIVED_TRANS_FLAG
         | DET_TRANS_CODE
         | DET_TRANS_DESCR
         | DIGITECH_ID
         | DIGITECH_TRANS_TYPE
         | DIGITECH_TRANS_TYPE_DET
         | DIV_LONG_NAME
         | DL_ISSUE_STATE
         | DL_NUM
         | DTE
         | EMP_NAME
         | EMP_TYPE
         | FED_TAX_ID
         | FIRE_ALM_AGING_RST_FLAG
         | FIRE_ORIG_ISSUE_DTE
         | FUNC_AREA_ID
         | FUND_CNTR_ID
         | FUND_ID
         | GL_ACCT_ID
         | HCTO_AD_VAL_ID
         | INCDT_ADDR_LINE_1
         | INCDT_ADDR_LINE_2
         | INCDT_ADDR_LINE_3
         | INCDT_APT_LOT
         | INCDT_CAT
         | INCDT_CITY
         | INCDT_CNTY
         | INCDT_CTRY
         | INCDT_DESCR
         | INCDT_DTE
         | INCDT_GIS_CITY
         | INCDT_GIS_LOCATR_NAME
         | INCDT_GIS_MATCH_SCORE
         | INCDT_GIS_PREFIX
         | INCDT_GIS_ST_NAME
         | INCDT_GIS_ST_NUM
         | INCDT_GIS_ST_PRETYPE
         | INCDT_GIS_ST_TYPE
         | INCDT_GIS_SUFF
         | INCDT_GIS_X
         | INCDT_GIS_Y
         | INCDT_GIS_ZIP
         | INCDT_IN_CITY_FLAG
         | INCDT_PREFIX
         | INCDT_SEQ_NUM
         | INCDT_SERV_LVL
         | INCDT_ST
         | INCDT_STATE
         | INCDT_ST_DIR
         | INCDT_ST_NAME
         | INCDT_ST_NUM
         | INCDT_ST_PRETYPE
         | INCDT_ST_TYPE
         | INCDT_SUFF
         | INCDT_TIME
         | INCDT_TYPE
         | INCDT_ZIP_CODE
         | INCDT_ZIP_PLUS_4
         | INTRA_FUND_TRANS_AMT
         | INTRA_FUND_TRANS_FLAG
         | INT_EXT_EMP_FLAG
         | INV_NUM
         | ITEM_ADDR_LINE_1
         | ITEM_ADDR_LINE_2
         | ITEM_ADDR_LINE_3
         | ITEM_APT_LOT
         | ITEM_CITY
         | ITEM_CNTY
         | ITEM_CTRY
         | ITEM_DESCR
         | ITEM_EXMPT_FLAG
         | ITEM_GIS_CITY
         | ITEM_GIS_LOCATR_NAME
         | ITEM_GIS_MATCH_SCORE
         | ITEM_GIS_PREFIX
         | ITEM_GIS_ST_NAME
         | ITEM_GIS_ST_NUM
         | ITEM_GIS_ST_PRETYPE
         | ITEM_GIS_ST_TYPE
         | ITEM_GIS_SUFF
         | ITEM_GIS_X
         | ITEM_GIS_Y
         | ITEM_GIS_ZIP
         | ITEM_IN_CITY_FLAG
         | ITEM_PREFIX
         | ITEM_SERV_LVL
         | ITEM_ST
         | ITEM_STAT
         | ITEM_STATE
         | ITEM_STAT_CHG_DTE
         | ITEM_ST_DIR
         | ITEM_ST_NAME
         | ITEM_ST_NUM
         | ITEM_ST_PRETYPE
         | ITEM_ST_TYPE
         | ITEM_SUFF
         | ITEM_TYPE
         | ITEM_ZIP_CODE
         | ITEM_ZIP_PLUS_4
         | JV_CUST_FLAG
         | LOAD_DTE
         | LOAD_TIME
         | MAN_TRANS_FLAG
         | MEDICAID_PAYER_CODE
         | MEDICARE_PAYER_CODE
         | MSTR_TRANS_TYPE
         | NAICS_DET_CODE
         | NAICS_DET_NAME
         | NAICS_DIV_CODE
         | NAICS_DIV_NAME
         | NAICS_INDY_CODE
         | NAICS_INDY_GRP_CODE
         | NAICS_INDY_GRP_NAME
         | NAICS_INDY_NAME
         | NAICS_MAJ_GRP_CODE
         | NAICS_MAJ_GRP_NAME
         | ORIG_BILL_NAME
         | PAY_METH
         | PERMIT_IS_CURR_AT_TIME_OF_INCDT_FLAG
         | PMAM_ADJMT_TO
         | PMAM_ADJMT_TYPE
         | PMAM_ID
         | POST_DTE
         | PRKG_METER_NUM
         | PRKG_METER_VIO_FLAG
         | RECEIVABLE_1ST_PAY_DTE
         | RECEIVABLE_EVER_TRANS_FLAG
         | RECEIVABLE_FNL_PAY_DTE
         | RECEIVABLE_LITIGATION_DTE
         | RECEIVABLE_MSTR_STAT
         | RECEIVABLE_MSTR_STAT_CHG_DTE
         | RECEIVABLE_SETTLEMENT_DTE
         | RECEIVABLE_STAT
         | RECEIVABLE_STAT_CHG_DTE
         | RECEIVABLE_VERS_BILLING_TO_DTE
         | RECEIVABLE_VERS_DELINQ_DTE
         | RECEIVABLE_VERS_DUE_DTE
         | RECEIVABLE_VERS_ISSUE_DTE
         | RECEIVABLE_VERS_TO_DTE
         | REINSTATEMENT_DTE
         | RM_EMP_MSTR_KEY
         | RM_LOAD_DTE
         | RM_LOAD_TIME
         | RSN_INCDT_NOT_BILLED
         | SAP_BUS_ID
         | SIC_CODE
         | SIC_DIV_CODE
         | SIC_DIV_NAME
         | SIC_INDY_GRP_CODE
         | SIC_INDY_GRP_NAME
         | SIC_MAJ_GRP_CODE
         | SIC_MAJ_GRP_NAME
         | SIC_NAME
         | SMARTCM_IS_ADJMT
         | SMARTCM_IS_FEE
         | SMARTCM_IS_PAY
         | SMARTCM_OTHER_CRITERIA
         | SMART_CM_ID
         | SRC_CARRIER_KEY
         | SRC_CARRIER_PROCEDURE_KEY
         | SRC_SYS
         | SRC_SYS_ID
         | SRC_SYS_MOD_DTE
         | SRC_SYS_TRANS_ID
         | STATE_CORP_CHTR_ID
         | STATE_SALES_TAX_ID
         | T2_ID
         | T2_TRANS_MISC_ITEM_CODE
         | T2_TRANS_MISC_ITEM_DESCR
         | T2_TRANS_ORIG_OBJ_TYPE_ID
         | T2_TRANS_PARSED_DESCR
         | T2_TRANS_RSN
         | T2_TRANS_SCENARIO
         | T2_TRANS_TYPE_CODE
         | T2_TRANS_TYPE_DESCR
         | TOWING_CMPNY
         | TRANS_AMT
         | TRANS_CNT
         | UNK_CUST_AT_BILL_FLAG
         | VERS_ASSIGNED_VEND
         | VIO_CODE
         | EMS_INCDT   
         | DISPATCH_NUM
         | FLAG_DIM_INCDT_EMS_DET
         | DEST_LOC
         | EMS_INCDT_CAT
         | ORIGIN_LOC
         | TXP_SERV_LVL
         | TXP_TYPE
         | VEH
         | FLAG_DIM_ITEM_BURG_ALM_PERMIT_DET
         | ALLOWABLE_NO_CHRG_INCDTS
         | ALM_MNT_CMPNY
         | ALM_TYPE
         | PERMIT_EXP_DTE
         | PERMIT_ISSUE_DTE
         | PERMIT_NAME
         | PERMIT_NUM
         | REG_HOLDER_FLAG
         | SUSPD_PERMIT_DTE
         | SUSPD_PERMIT_RSN
         | TYPE_OF_ALM_SITE
         | FLAG_DIM_ITEM_FIRE_ALM_PERMIT_DET
         | ALM_INSTL_CMPNY
         | ALM_INSTL_DTE
         | ALM_REG_KEY
         | APPLICTN_RECV_DTE
         | CURR_FIRE_ALM_PERMIT_FLAG
         | EXCL_TYPE
         | FIRE_ALM_PERMIT_ACTV_FLAG
         | FIRE_ALM_PERMIT_NUM
         | FIRE_ALM_PURPOSE
         | FLAG_DIM_ITEM_LICENSED_VEH_DET
         | LICENSE_PLATE_EXP_MTH
         | LICENSE_PLATE_EXP_YR
         | LICENSE_PLATE_NUM
         | LICENSE_PLATE_TYPE
         | OWNER_IS_CUST_FLAG
         | SRC_SYS_VEH_ID
         | VEH_COLOR
         | VEH_ID_NUM
         | VEH_MAKE
         | VEH_MODEL
         | VEH_MODEL_YR
         | VEH_OWNER_ID
         | VEH_OWNER_NAME
         | VEH_TYPE
         | FLAG_DIM_ITEM_PT_DET
         | PT_AGE
         | PT_GNDR
         | FLAG_DIM_ITEM_TAXABLE_PROP_DET
         | APPRAISAL_DISTR_ACCT_NUM
         | CAN
         | CC_JURIS_CODE
         | CC_JURIS_DESCR
         | CITY_RFPD_JURIS_CODE
         | CITY_RFPD_JURIS_DESCR
         | CONFI_ACCT_FLAG
         | MUNIC_UTIL_DISTR_CODE
         | MUNIC_UTIL_DISTR_DESCR
         | NUM_OF_ACRES
         | OWNERSHIP_EFF_DTE
         | PROP_CLASS_CODE
         | PROP_CLASS_DESCR
         | REND_PENALTY_JURIS_CODE
         | REND_PENALTY_JURIS_DESCR
         | SCHOOL_JURIS_CODE
         | SCHOOL_JURIS_DESCR
         | SUBSTANTIAL_ERR_PENALTY
         | TAX_DEFERRAL_END_DTE
         | TAX_DEFERRAL_START_DTE
         | TAX_ROLL_CODE
         | TAX_ROLL_DESCR
         | TAXABLE_PROP_LGL_DESCR_1
         | TAXABLE_PROP_LGL_DESCR_2
         | TAXABLE_PROP_LGL_DESCR_3
         | TAXABLE_PROP_LGL_DESCR_4
         | TAXABLE_PROP_LGL_DESCR_5
         | TAXABLE_PROP_ROLL_TYPE
         | FLAG_DIM_ITEM_WTR_ACCT_DET
         | CURR_WTR_ACCT_FLAG
         | DELINQ_DTE
         | LAST_CUST_CONN_DTE
         | LAST_CUST_CUTOFF_DTE
         | LAST_CUST_DISCONN_DTE
         | LAST_METER_INSPECT_DTE
         | OWNER_RENTER
         | SEN_CITIZEN_FLAG
         | VAC_FLAG
         | WTR_ACCT_NUM_OF_UNITS
         | WTR_ACCT_ORIG_USE_TYPE
         | WTR_ACCT_PROP_USE_TYPE
         | WTR_METER_NUM
         | FLAG_DIM_RECEIVABLE_AD_VAL_RECEIVABLE_DET
         | ``A#3307_ATTY_FEE_DTE``
         | ``A#3308_ATTY_FEE_DTE``
         | ``A#3348_ATTY_FEE_DTE``
         | AD_VAL_ACCT_LVL_ID
         | AD_VAL_DISABLED_FLAG
         | AD_VAL_EFF_DTE_OF_OWNERSHIP
         | AD_VAL_HOMESTEAD_FLAG
         | AD_VAL_OVER_66_FLAG
         | AD_VAL_TAX_DEFERRAL_END_DTE
         | AD_VAL_TAX_DEFERRAL_START_DTE
         | AD_VAL_VET_FLAG
         | COLL_LAWSUIT_NUM
         | COLL_LGL_COND
         | HCAD_ACCT_STAT
         | QTRLY_PAY_FLAG
         | FLAG_DIM_RECEIVABLE_BOOT_TOW_DET
         | RECEIVABLE_HAS_LTR_FLAG
         | RECEIVABLE_HAS_NOTE_FLAG
         | RECEIVABLE_HAS_PEND_LTR_FLAG
         | RESOLVE_DESCR
         | RESOLVE_DTE
         | RESOLVE_RSN
         | RESOLVED_BY
         | FLAG_DIM_RECEIVABLE_EMS_RECEIVABLE_DET
         | ACTV_CARRIER
         | ACTV_CARRIER_FIN_CLASS
         | ACTV_CARRIER_FIN_GRP
         | BILLING_HOLD_FLAG
         | SIG_FLAG
         | FLAG_DIM_RECEIVABLE_FIRE_ALM_CIT_DET
         | VOID_CODE
         | VOID_DESCR
         | WORK_STAT
         | FLAG_DIM_RECEIVABLE_PRKG_CONTRA_DET
         | ESC_CAND_FLAG
         | ON_ADMIN_HOLD_FLAG
         | UNDER_APPEAL_FLAG
         | VOID_FLAG
         | WRITE_OFF_FLAG
         | Nil_
    
//"(4) F# FieldDecls.fsx"
    let fieldDecl = [|
        ("3307_ATTY_FEE_DTE", "datetime", 0)
        ("3308_ATTY_FEE_DTE", "datetime", 0)
        ("3348_ATTY_FEE_DTE", "datetime", 0)
        ("ACCT_GRP_DESCR", "varchar(30)", 0)
        ("ACCT_GRP_ID", "varchar(4)", 0)
        ("ACTV_CARRIER", "varchar(120)", 0)
        ("ACTV_CARRIER_FIN_CLASS", "varchar(40)", 0)
        ("ACTV_CARRIER_FIN_GRP", "varchar(40)", 0)
        ("AD_VAL_ACCT_LVL_ID", "varchar(4)", 1)
        ("AD_VAL_DISABLED_FLAG", "varchar(1)", 0)
        ("AD_VAL_EFF_DTE_OF_OWNERSHIP", "datetime", 0)
        ("AD_VAL_HOMESTEAD_FLAG", "varchar(1)", 0)
        ("AD_VAL_OVER_66_FLAG", "varchar(1)", 0)
        ("AD_VAL_TAX_DEFERRAL_END_DTE", "datetime", 0)
        ("AD_VAL_TAX_DEFERRAL_START_DTE", "datetime", 0)
        ("AD_VAL_VET_FLAG", "varchar(1)", 0)
        ("ADDR_ID", "varchar(10)", 0)
        ("ADJ_FLAG", "varchar(1)", 0)
        ("ALLOC_TRANS_FLAG", "varchar(1)", 0)
        ("ALLOWABLE_NO_CHRG_INCDTS", "int", 0)
        ("ALM_INSTL_CMPNY", "varchar(50)", 0)
        ("ALM_INSTL_DTE", "datetime", 0)
        ("ALM_MNT_CMPNY", "varchar(50)", 0)
        ("ALM_REG_KEY", "varchar(20)", 0)
        ("ALM_TYPE", "varchar(2)", 0)
        ("ALT_PAYEE_NUM", "varchar(10)", 0)
        ("AM_PM", "varchar(2)", 0)
        ("APPLICTN_RECV_DTE", "datetime", 0)
        ("APPRAISAL_DISTR_ACCT_NUM", "varchar(16)", 0)
        ("AUTH_GRP_ID", "varchar(10)", 0)
        ("BAL_SHT_ACCT_FLAG", "varchar(1)", 0)
        ("BAL_UPD_IND", "varchar(1)", 0)
        ("BILLED_FLAG", "varchar(1)", 0)
        ("BILLING_HOLD_FLAG", "varchar(1)", 0)
        ("BLANK_BUD_PER_ALLOWED", "varchar(1)", 0)
        ("BLK_NUM", "varchar(8)", 0)
        ("BOOT_SERIAL_NUM", "varchar(32)", 0)
        ("BUS_AREA_DESCR", "varchar(30)", 0)
        ("BUS_AREA_FULL_NAME", "varchar(120)", 0)
        ("BUS_AREA_ID", "varchar(4)", 0)
        ("BUS_AREA_KEY", "int", 0)
        ("BUS_CONT_PERSON_NAME", "varchar(40)", 0)
        ("CAL_DAY_OF_MTH_NUM", "int", 0)
        ("CAL_MTH", "varchar(15)", 0)
        ("CAL_MTH_NUM", "int", 0)
        ("CAL_PER", "varchar(20)", 1)
        ("CAL_QTR", "varchar(15)", 1)
        ("CAL_QTR_NUM", "int", 0)
        ("CAL_WK_ENDING_SAT", "varchar(15)", 0)
        ("CAL_YR", "int", 0)
        ("CAN", "varchar(16)", 1)
        ("CARRIER_FIN_CLASS", "varchar(40)", 0)
        ("CARRIER_FIN_GRP", "varchar(40)", 0)
        ("CARRIER_GRP", "varchar(40)", 0)
        ("CARRIER_KEY", "int", 0)
        ("CARRIER_NAME", "varchar(120)", 0)
        ("CARRIER_PROCEDURE_BILL_CODE", "varchar(40)", 0)
        ("CARRIER_PROCEDURE_CODE", "varchar(40)", 0)
        ("CARRIER_PROCEDURE_DESCR", "varchar(120)", 0)
        ("CARRIER_PROCEDURE_KEY", "int", 0)
        ("CARRIER_PROCEDURE_SRC", "varchar(120)", 0)
        ("CARRIER_PROCEDURE_TYPE", "varchar(40)", 0)
        ("CARRIER_SRC", "varchar(120)", 0)
        ("CC_JURIS_CODE", "varchar(13)", 1)
        ("CC_JURIS_DESCR", "varchar(50)", 0)
        ("CENTRAL_POSTING_BLK", "varchar(1)", 0)
        ("CENTRALLY_IMPOSED_PURCH_BLK", "varchar(1)", 0)
        ("CHGED_BY", "varchar(12)", 0)
        ("CHGED_ON", "datetime", 0)
        ("CHGED_ON_DTE", "datetime", 0)
        ("CHRT_OF_ACCT_FULL_NAME", "varchar(120)", 0)
        ("CHRT_OF_ACCT_ID", "varchar(4)", 0)
        ("CHRT_OF_ACCT_NAME", "varchar(50)", 0)
        ("CITY", "varchar(40)", 0)
        ("CITY_BUS_DAY", "varchar(40)", 1)
        ("CITY_HOL_FLAG", "varchar(1)", 0)
        ("CITY_RFPD_JURIS_CODE", "varchar(13)", 1)
        ("CITY_RFPD_JURIS_DESCR", "varchar(50)", 0)
        ("CMPNY_CODE_ID", "varchar(4)", 0)
        ("CMPNY_CODE_NAME", "varchar(25)", 0)
        ("COH", "varchar(20)", 1)
        ("COH_EMP_NUM", "varchar(8)", 0)
        ("COH_ORG_KEY", "int", 0)
        ("COLL_BID_NUM", "varchar(10)", 0)
        ("COLL_LAWSUIT_NUM", "varchar(7)", 0)
        ("COLL_LGL_COND", "varchar(100)", 0)
        ("COLL_PERSON_ID", "varchar(20)", 0)
        ("COLL_PERSON_KEY", "int", 0)
        ("COLL_PERSON_NAME", "varchar(120)", 0)
        ("COLL_PERSON_TYPE", "varchar(40)", 0)
        ("COLL_VEND_CONTR_KEY", "int", 0)
        ("CONFI_ACCT_FLAG", "varchar(2)", 1)
        ("CONFI_CUST_FLAG", "varchar(1)", 0)
        ("CONTR_DESCR", "varchar(1000)", 1)
        ("CONTR_ID", "varchar(10)", 0)
        ("CONTR_KEY", "int", 0)
        ("CONTR_LIFE_PRIOD", "int", 0)
        ("CONTR_PER_KEY", "int", 0)
        ("CONTR_REV_STREAM", "varchar(50)", 1)
        ("CONTR_YR", "varchar(15)", 0)
        ("CONTR_YR_PER", "varchar(15)", 0)
        ("CR_INFO_ID", "varchar(11)", 0)
        ("CREATE_DTE", "datetime", 0)
        ("CREATED_BY", "varchar(12)", 0)
        ("CTRL_AREA_DESCR", "varchar(20)", 0)
        ("CTRL_AREA_ID", "varchar(4)", 0)
        ("CTRY_ID", "varchar(3)", 0)
        ("CTRY_NAME", "varchar(15)", 0)
        ("CURR_ASSIGNED_VEND", "varchar(120)", 1)
        ("CURR_FIRE_ALM_PERMIT_FLAG", "varchar(1)", 0)
        ("CURR_VERS_FLAG", "varchar(1)", 0)
        ("CURR_WTR_ACCT_FLAG", "varchar(1)", 0)
        ("CUST_ADDR_LINE_1", "varchar(200)", 0)
        ("CUST_ADDR_LINE_2", "varchar(200)", 0)
        ("CUST_ADDR_LINE_3", "varchar(200)", 0)
        ("CUST_APT_LOT", "varchar(20)", 0)
        ("CUST_CITY", "varchar(40)", 1)
        ("CUST_CNTY", "varchar(20)", 0)
        ("CUST_CTRY", "varchar(32)", 1)
        ("CUST_EMAIL_ADDR", "varchar(100)", 0)
        ("CUST_FAX_NUM", "varchar(15)", 0)
        ("CUST_GIS_CITY", "varchar(20)", 0)
        ("CUST_GIS_CMPLT_MATCH_ADDR", "varchar(200)", 1)
        ("CUST_GIS_LAT", "varchar(38)", 1)
        ("CUST_GIS_LOCATR_NAME", "varchar(40)", 0)
        ("CUST_GIS_LONG", "varchar(38)", 1)
        ("CUST_GIS_MATCH_SCORE", "varchar(10)", 1)
        ("CUST_GIS_PREFIX", "varchar(12)", 1)
        ("CUST_GIS_ST_NAME", "varchar(60)", 1)
        ("CUST_GIS_ST_NUM", "varchar(12)", 1)
        ("CUST_GIS_ST_PRETYPE", "varchar(40)", 1)
        ("CUST_GIS_ST_TYPE", "varchar(40)", 1)
        ("CUST_GIS_SUFF", "varchar(12)", 1)
        ("CUST_GIS_X", "varchar(21)", 1)
        ("CUST_GIS_Y", "varchar(17)", 1)
        ("CUST_GIS_ZIP", "varchar(5)", 0)
        ("CUST_ID", "varchar(120)", 0)
        ("CUST_IN_CITY_FLAG", "varchar(1)", 0)
        ("CUST_IS_VEND_FLAG", "varchar(1)", 0)
        ("CUST_KEY", "int", 0)
        ("CUST_NAME", "varchar(120)", 0)
        ("CUST_PAR_ADDR_LINE_1", "varchar(200)", 0)
        ("CUST_PAR_ADDR_LINE_2", "varchar(200)", 0)
        ("CUST_PAR_ADDR_LINE_3", "varchar(200)", 0)
        ("CUST_PAR_APT_LOT", "varchar(20)", 0)
        ("CUST_PAR_CITY", "varchar(20)", 0)
        ("CUST_PAR_CNTY", "varchar(20)", 0)
        ("CUST_PAR_CTRY", "varchar(20)", 0)
        ("CUST_PAR_GIS_CITY", "varchar(20)", 0)
        ("CUST_PAR_GIS_LOCATR_NAME", "varchar(40)", 0)
        ("CUST_PAR_GIS_MATCH_SCORE", "varchar(3)", 1)
        ("CUST_PAR_GIS_PREFIX", "varchar(2)", 0)
        ("CUST_PAR_GIS_ST_NAME", "varchar(35)", 0)
        ("CUST_PAR_GIS_ST_NUM", "varchar(7)", 0)
        ("CUST_PAR_GIS_ST_PRETYPE", "varchar(15)", 0)
        ("CUST_PAR_GIS_ST_TYPE", "varchar(4)", 0)
        ("CUST_PAR_GIS_SUFF", "varchar(2)", 0)
        ("CUST_PAR_GIS_X", "varchar(17)", 1)
        ("CUST_PAR_GIS_Y", "varchar(17)", 1)
        ("CUST_PAR_GIS_ZIP", "varchar(5)", 0)
        ("CUST_PAR_ID", "varchar(40)", 0)
        ("CUST_PAR_IN_CITY_FLAG", "varchar(1)", 0)
        ("CUST_PAR_KEY", "int", 0)
        ("CUST_PAR_NAME", "varchar(40)", 0)
        ("CUST_PAR_PREFIX", "varchar(2)", 1)
        ("CUST_PAR_SERV_LVL", "varchar(40)", 0)
        ("CUST_PAR_ST", "varchar(100)", 0)
        ("CUST_PAR_ST_DIR", "varchar(4)", 0)
        ("CUST_PAR_ST_NAME", "varchar(35)", 0)
        ("CUST_PAR_ST_NUM", "varchar(7)", 0)
        ("CUST_PAR_ST_PRETYPE", "varchar(15)", 0)
        ("CUST_PAR_ST_TYPE", "varchar(4)", 0)
        ("CUST_PAR_STATE", "varchar(25)", 0)
        ("CUST_PAR_SUFF", "varchar(2)", 0)
        ("CUST_PAR_ZIP_CODE", "varchar(6)", 0)
        ("CUST_PAR_ZIP_PLUS_4", "varchar(11)", 0)
        ("CUST_PHN_NUM_1", "varchar(20)", 1)
        ("CUST_PHN_NUM_2", "varchar(20)", 1)
        ("CUST_PHN_NUM_3", "varchar(20)", 1)
        ("CUST_PREFIX", "varchar(2)", 1)
        ("CUST_SERV_LVL", "varchar(40)", 0)
        ("CUST_ST", "varchar(100)", 0)
        ("CUST_ST_DIR", "varchar(4)", 0)
        ("CUST_ST_NAME", "varchar(35)", 0)
        ("CUST_ST_NUM", "varchar(7)", 0)
        ("CUST_ST_PRETYPE", "varchar(15)", 0)
        ("CUST_ST_TYPE", "varchar(4)", 0)
        ("CUST_STATE", "varchar(25)", 0)
        ("CUST_SUFF", "varchar(2)", 0)
        ("CUST_TYPE", "varchar(13)", 1)
        ("CUST_ZIP_CODE", "varchar(32)", 1)
        ("CUST_ZIP_PLUS_4", "varchar(13)", 1)
        ("DAY_OF_WK", "varchar(9)", 0)
        ("DAY_OF_WK_NUM", "int", 0)
        ("DEC_CUST_FLAG", "varchar(1)", 0)
        ("DEL_FLAG", "varchar(1)", 0)
        ("DELINQ_DTE", "datetime", 0)
        ("DELIV_POLICY_FLAG", "varchar(1)", 0)
        ("DEPT_LONG_NAME", "varchar(120)", 1)
        ("DEPT_NAME", "varchar(30)", 1)
        ("DERIVED_NODE_FLAG", "varchar(1)", 0)
        ("DERIVED_PAR_CUST_FLAG", "varchar(1)", 0)
        ("DERIVED_TRANS_FLAG", "varchar(1)", 0)
        ("DEST_LOC", "varchar(120)", 0)
        ("DET_TRANS_CODE", "varchar(20)", 0)
        ("DET_TRANS_DESCR", "varchar(50)", 0)
        ("DIGITECH_ID", "varchar(20)", 1)
        ("DIGITECH_TRANS_TYPE", "varchar(40)", 1)
        ("DIGITECH_TRANS_TYPE_DET", "varchar(120)", 1)
        ("DISASTER_FLAG", "varchar(1)", 0)
        ("DISPATCH_NUM", "varchar(40)", 0)
        ("DISTR", "varchar(40)", 0)
        ("DIV_LONG_NAME", "varchar(120)", 1)
        ("DIV_NAME", "varchar(30)", 1)
        ("DL_ISSUE_STATE", "varchar(20)", 0)
        ("DL_NUM", "varchar(20)", 0)
        ("DST_EX_MIN_FLAG", "varchar(1)", 0)
        ("DTE", "date", 0)
        ("DTE_FISC_PER_KEY", "int", 0)
        ("DTE_KEY", "int", 0)
        ("EMP_KEY", "int", 0)
        ("EMP_NAME", "varchar(120)", 0)
        ("EMP_TYPE", "varchar(40)", 0)
        ("EMS_INCDT", "varchar(40)", 0)
        ("EMS_INCDT_CAT", "varchar(120)", 0)
        ("ENTRY_DTE", "datetime", 0)
        ("ESC_CAND_FLAG", "varchar(1)", 0)
        ("ETL_PROC_USED", "varchar(50)", 0)
        ("EXCH_RATE_LOCAL", "numeric", 0)
        ("EXCL_TYPE", "varchar(50)", 0)
        ("EXP_DTE", "datetime", 0)
        ("EXTRACT_DTE_TIME", "datetime", 0)
        ("EXTRACT_PROC_USED", "varchar(50)", 0)
        ("FAX", "varchar(40)", 0)
        ("FED_FISC_PER", "varchar(15)", 0)
        ("FED_FISC_PER_NUM", "int", 0)
        ("FED_FISC_QTR", "varchar(15)", 1)
        ("FED_FISC_QTR_NUM", "int", 0)
        ("FED_FISC_YR", "varchar(15)", 1)
        ("FED_TAX_ID", "varchar(40)", 0)
        ("FG_FIN_TRANS_KEY", "int", 0)
        ("FIN_MGMT_AREA", "varchar(4)", 0)
        ("FIN_MGMT_AREA_DESCR", "varchar(25)", 0)
        ("FIN_TRANS_TYPE_KEY", "int", 0)
        ("FIRE_ALM_AGING_RST_FLAG", "varchar(1)", 0)
        ("FIRE_ALM_PERMIT_ACTV_FLAG", "varchar(1)", 0)
        ("FIRE_ALM_PERMIT_NUM", "varchar(20)", 0)
        ("FIRE_ALM_PURPOSE", "varchar(50)", 0)
        ("FIRE_ORIG_ISSUE_DTE", "datetime", 0)
        ("FISC_PER", "varchar(15)", 0)
        ("FISC_PER_ANNUAL_SORT_ORD", "int", 0)
        ("FISC_PER_NUM", "int", 0)
        ("FISC_QTR", "varchar(15)", 0)
        ("FISC_QTR_NUM", "int", 0)
        ("FISC_YR", "int", 0)
        ("FISC_YR_VARIANT", "varchar(2)", 0)
        ("FM_AUTH_GRP", "varchar(10)", 0)
        ("FM_FINUSE", "varchar(16)", 0)
        ("FM_SPONSER", "varchar(10)", 0)
        ("FUNC_AREA_DESCR", "varchar(30)", 0)
        ("FUNC_AREA_FULL_NAME", "varchar(120)", 0)
        ("FUNC_AREA_ID", "varchar(16)", 0)
        ("FUNC_AREA_KEY", "int", 0)
        ("FUNC_THAT_WILL_BE_BLKED", "varchar(2)", 1)
        ("FUND_BUD_PROF", "varchar(6)", 0)
        ("FUND_CNTR_DESCR", "varchar(40)", 0)
        ("FUND_CNTR_FULL_NAME", "varchar(120)", 0)
        ("FUND_CNTR_ID", "varchar(16)", 0)
        ("FUND_CNTR_KEY", "int", 0)
        ("FUND_CNTR_NAME", "varchar(20)", 0)
        ("FUND_DESCR", "varchar(40)", 0)
        ("FUND_ID", "varchar(10)", 0)
        ("FUND_KEY", "int", 0)
        ("FUND_NAME", "varchar(20)", 0)
        ("FUND_SUBSTR1", "varchar(10)", 0)
        ("FUND_SUBSTR2", "varchar(10)", 0)
        ("FUND_TYPE_DESCR", "varchar(35)", 0)
        ("FUND_TYPE_ID", "varchar(6)", 0)
        ("GL_ACCT_FULL_NAME", "varchar(120)", 0)
        ("GL_ACCT_GRP", "varchar(4)", 0)
        ("GL_ACCT_ID", "varchar(30)", 0)
        ("GL_ACCT_KEY", "int", 0)
        ("GL_ACCT_MSTR_DESCR", "varchar(64)", 0)
        ("GL_COMBO_KEY", "int", 0)
        ("GRP_ACCT_NUM", "varchar(10)", 0)
        ("HCAD_ACCT_STAT", "varchar(100)", 0)
        ("HCTO_AD_VAL_ID", "varchar(22)", 1)
        ("HCTO_DET_TRANS_DESCR", "varchar(50)", 1)
        ("HCTO_FISC_PER", "varchar(15)", 0)
        ("HCTO_FISC_PER_NUM", "int", 0)
        ("HCTO_FISC_QTR", "varchar(15)", 1)
        ("HCTO_FISC_QTR_NUM", "int", 0)
        ("HCTO_FISC_YR", "varchar(15)", 1)
        ("HH", "varchar(2)", 0)
        ("HIER_ID", "varchar(30)", 0)
        ("HOL_DESCR", "varchar(40)", 1)
        ("HOUSE_NUM", "varchar(10)", 0)
        ("INCDT_ADDR_LINE_1", "varchar(200)", 0)
        ("INCDT_ADDR_LINE_2", "varchar(200)", 0)
        ("INCDT_ADDR_LINE_3", "varchar(200)", 0)
        ("INCDT_APT_LOT", "varchar(20)", 0)
        ("INCDT_CAT", "varchar(40)", 0)
        ("INCDT_CITY", "varchar(20)", 0)
        ("INCDT_CNTY", "varchar(20)", 0)
        ("INCDT_CTRY", "varchar(20)", 0)
        ("INCDT_DESCR", "varchar(40)", 0)
        ("INCDT_DTE", "datetime", 0)
        ("INCDT_GIS_CITY", "varchar(20)", 0)
        ("INCDT_GIS_CMPLT_MATCH_ADDR", "varchar(200)", 1)
        ("INCDT_GIS_LAT", "varchar(38)", 1)
        ("INCDT_GIS_LOCATR_NAME", "varchar(40)", 0)
        ("INCDT_GIS_LONG", "varchar(38)", 1)
        ("INCDT_GIS_MATCH_SCORE", "varchar(10)", 1)
        ("INCDT_GIS_PREFIX", "varchar(12)", 1)
        ("INCDT_GIS_ST_NAME", "varchar(60)", 1)
        ("INCDT_GIS_ST_NUM", "varchar(12)", 1)
        ("INCDT_GIS_ST_PRETYPE", "varchar(40)", 1)
        ("INCDT_GIS_ST_TYPE", "varchar(40)", 1)
        ("INCDT_GIS_SUFF", "varchar(12)", 1)
        ("INCDT_GIS_X", "varchar(21)", 1)
        ("INCDT_GIS_Y", "varchar(17)", 0)
        ("INCDT_GIS_ZIP", "varchar(5)", 0)
        ("INCDT_IN_CITY_FLAG", "varchar(1)", 0)
        ("INCDT_KEY", "int", 0)
        ("INCDT_PREFIX", "varchar(2)", 0)
        ("INCDT_SEQ_NUM", "varchar(10)", 0)
        ("INCDT_SERV_LVL", "varchar(120)", 0)
        ("INCDT_ST", "varchar(100)", 0)
        ("INCDT_ST_DIR", "varchar(4)", 0)
        ("INCDT_ST_NAME", "varchar(35)", 0)
        ("INCDT_ST_NUM", "varchar(7)", 0)
        ("INCDT_ST_PRETYPE", "varchar(15)", 0)
        ("INCDT_ST_TYPE", "varchar(4)", 0)
        ("INCDT_STATE", "varchar(25)", 0)
        ("INCDT_SUFF", "varchar(2)", 0)
        ("INCDT_TIME", "varchar(8)", 0)
        ("INCDT_TYPE", "varchar(40)", 0)
        ("INCDT_ZIP_CODE", "varchar(6)", 0)
        ("INCDT_ZIP_PLUS_4", "varchar(11)", 0)
        ("INDY_DESCR", "varchar(20)", 0)
        ("INDY_ID", "varchar(4)", 0)
        ("INT_EXT_EMP_FLAG", "varchar(1)", 0)
        ("INTER_CMPNY_TERM02_NAME", "varchar(28)", 0)
        ("INTRA_FUND_TRANS_AMT", "money", 1)
        ("INTRA_FUND_TRANS_FLAG", "varchar(1)", 0)
        ("INV_NUM", "varchar(40)", 0)
        ("INVALID INPUT", "nvarchar(100)", 1)
        ("INVALID INPUT ERROR DESCRIPTION", "nvarchar(1000)", 1)
        ("ITEM_ADDR_LINE_1", "varchar(200)", 0)
        ("ITEM_ADDR_LINE_2", "varchar(200)", 0)
        ("ITEM_ADDR_LINE_3", "varchar(200)", 0)
        ("ITEM_APT_LOT", "varchar(20)", 0)
        ("ITEM_CITY", "varchar(20)", 0)
        ("ITEM_CNTY", "varchar(20)", 0)
        ("ITEM_CTRY", "varchar(20)", 0)
        ("ITEM_DESCR", "varchar(255)", 1)
        ("ITEM_EXMPT_FLAG", "varchar(1)", 0)
        ("ITEM_GIS_CITY", "varchar(20)", 0)
        ("ITEM_GIS_CMPLT_MATCH_ADDR", "varchar(200)", 1)
        ("ITEM_GIS_LAT", "varchar(38)", 1)
        ("ITEM_GIS_LOCATR_NAME", "varchar(40)", 0)
        ("ITEM_GIS_LONG", "varchar(38)", 1)
        ("ITEM_GIS_MATCH_SCORE", "varchar(10)", 1)
        ("ITEM_GIS_PREFIX", "varchar(12)", 1)
        ("ITEM_GIS_ST_NAME", "varchar(60)", 1)
        ("ITEM_GIS_ST_NUM", "varchar(12)", 1)
        ("ITEM_GIS_ST_PRETYPE", "varchar(40)", 1)
        ("ITEM_GIS_ST_TYPE", "varchar(40)", 1)
        ("ITEM_GIS_SUFF", "varchar(12)", 1)
        ("ITEM_GIS_X", "varchar(21)", 1)
        ("ITEM_GIS_Y", "varchar(17)", 0)
        ("ITEM_GIS_ZIP", "varchar(5)", 0)
        ("ITEM_IN_CITY_FLAG", "varchar(1)", 0)
        ("ITEM_KEY", "int", 0)
        ("ITEM_PREFIX", "varchar(2)", 0)
        ("ITEM_SERV_LVL", "varchar(40)", 0)
        ("ITEM_ST", "varchar(100)", 0)
        ("ITEM_ST_DIR", "varchar(4)", 0)
        ("ITEM_ST_NAME", "varchar(35)", 0)
        ("ITEM_ST_NUM", "varchar(13)", 1)
        ("ITEM_ST_PRETYPE", "varchar(15)", 0)
        ("ITEM_ST_TYPE", "varchar(4)", 0)
        ("ITEM_STAT", "varchar(40)", 0)
        ("ITEM_STAT_CHG_DTE", "datetime", 0)
        ("ITEM_STATE", "varchar(25)", 0)
        ("ITEM_SUFF", "varchar(2)", 0)
        ("ITEM_TYPE", "varchar(40)", 0)
        ("ITEM_ZIP_CODE", "varchar(13)", 1)
        ("ITEM_ZIP_PLUS_4", "varchar(11)", 0)
        ("JV_CUST_FLAG", "varchar(1)", 0)
        ("LANG_ID", "varchar(1)", 0)
        ("LAST_CUST_CONN_DTE", "datetime", 0)
        ("LAST_CUST_CUTOFF_DTE", "datetime", 0)
        ("LAST_CUST_DISCONN_DTE", "datetime", 0)
        ("LAST_METER_INSPECT_DTE", "datetime", 0)
        ("LICENSE_PLATE_EXP_MTH", "varchar(3)", 0)
        ("LICENSE_PLATE_EXP_YR", "varchar(4)", 0)
        ("LICENSE_PLATE_NUM", "varchar(10)", 0)
        ("LICENSE_PLATE_TYPE", "varchar(20)", 0)
        ("LOAD_DTE", "datetime", 0)
        ("LOAD_DTE_TIME", "datetime", 0)
        ("LOAD_TIME", "varchar(8)", 0)
        ("LOGICAL_SYS", "varchar(10)", 0)
        ("MAN_TRANS_FLAG", "varchar(1)", 0)
        ("MEDICAID_PAYER_CODE", "varchar(40)", 0)
        ("MEDICARE_PAYER_CODE", "varchar(40)", 0)
        ("MIN", "varchar(5)", 0)
        ("MSTR_REC_CNTRL_DEL_BLK", "varchar(1)", 0)
        ("MSTR_SUBDIV_ID", "varchar(10)", 0)
        ("MSTR_TRANS_TYPE", "varchar(20)", 0)
        ("MUNIC_UTIL_DISTR_CODE", "varchar(13)", 1)
        ("MUNIC_UTIL_DISTR_DESCR", "varchar(50)", 0)
        ("NAICS_DET_CODE", "varchar(6)", 0)
        ("NAICS_DET_NAME", "varchar(40)", 0)
        ("NAICS_DIV_CODE", "varchar(2)", 0)
        ("NAICS_DIV_NAME", "varchar(40)", 0)
        ("NAICS_INDY_CODE", "varchar(5)", 0)
        ("NAICS_INDY_GRP_CODE", "varchar(4)", 0)
        ("NAICS_INDY_GRP_NAME", "varchar(40)", 0)
        ("NAICS_INDY_NAME", "varchar(40)", 0)
        ("NAICS_MAJ_GRP_CODE", "varchar(3)", 0)
        ("NAICS_MAJ_GRP_NAME", "varchar(40)", 0)
        ("NODE_FLAG", "varchar(1)", 0)
        ("NUM_OF_ACRES", "varchar(13)", 1)
        ("ON_ADMIN_HOLD_FLAG", "varchar(1)", 0)
        ("ONE_TIME_ACCT_DESCR", "varchar(5)", 0)
        ("ORIG_ASSIGNED_VEND", "varchar(120)", 1)
        ("ORIG_BILL_NAME", "varchar(120)", 1)
        ("ORIG_CUST_KEY", "int", 0)
        ("ORIG_INV_NUM", "varchar(40)", 0)
        ("ORIGIN_LOC", "varchar(120)", 0)
        ("OWNER_IS_CUST_FLAG", "varchar(1)", 0)
        ("OWNER_RENTER", "varchar(1)", 0)
        ("OWNERSHIP_EFF_DTE", "datetime", 0)
        ("PAY_BLK", "varchar(1)", 0)
        ("PAY_METH", "varchar(15)", 0)
        ("PAYROLL_PER", "int", 0)
        ("PER_END_DTE", "date", 1)
        ("PERMIT_EXP_DTE", "datetime", 0)
        ("PERMIT_IS_CURR_AT_TIME_OF_INCDT_FLAG", "varchar(1)", 0)
        ("PERMIT_ISSUE_DTE", "datetime", 0)
        ("PERMIT_NAME", "varchar(120)", 0)
        ("PERMIT_NUM", "int", 0)
        ("PERSON_IN_CHRG", "varchar(20)", 0)
        ("PERSON_IN_CHRG_ID", "varchar(8)", 0)
        ("PHN", "varchar(30)", 0)
        ("PL_STMNT_ACCT_TYPE", "varchar(2)", 0)
        ("PLANT_ID", "varchar(4)", 0)
        ("PLANT_NAME", "varchar(30)", 0)
        ("PMAM_ADJMT_TO", "varchar(20)", 1)
        ("PMAM_ADJMT_TYPE", "varchar(50)", 1)
        ("PMAM_ID", "varchar(20)", 0)
        ("POST_DTE_KEY", "int", 1)
        ("PRKG_METER_NUM", "varchar(8)", 0)
        ("PRKG_METER_VIO_FLAG", "varchar(1)", 0)
        ("PROP_CLASS_CODE", "varchar(13)", 1)
        ("PROP_CLASS_DESCR", "varchar(50)", 0)
        ("PT_AGE", "varchar(3)", 0)
        ("PT_GNDR", "varchar(10)", 0)
        ("QTRLY_PAY_FLAG", "varchar(1)", 0)
        ("RECEIVABLE_1ST_PAY_DTE", "datetime", 1)
        ("RECEIVABLE_CURR_BILLING_TO_DTE", "datetime", 1)
        ("RECEIVABLE_CURR_DELINQ_DTE", "datetime", 0)
        ("RECEIVABLE_CURR_DUE_DTE", "datetime", 0)
        ("RECEIVABLE_CURR_ISSUE_DTE", "datetime", 0)
        ("RECEIVABLE_CURR_TO_DTE", "datetime", 1)
        ("RECEIVABLE_EVER_TRANS_FLAG", "varchar(1)", 1)
        ("RECEIVABLE_FNL_PAY_DTE", "datetime", 1)
        ("RECEIVABLE_HAS_LTR_FLAG", "varchar(1)", 0)
        ("RECEIVABLE_HAS_NOTE_FLAG", "varchar(1)", 0)
        ("RECEIVABLE_HAS_PEND_LTR_FLAG", "varchar(1)", 0)
        ("RECEIVABLE_KEY", "int", 0)
        ("RECEIVABLE_LITIGATION_DTE", "datetime", 1)
        ("RECEIVABLE_MSTR_STAT", "varchar(40)", 1)
        ("RECEIVABLE_MSTR_STAT_CHG_DTE", "datetime", 1)
        ("RECEIVABLE_ORIG_BILLING_TO_DTE", "datetime", 1)
        ("RECEIVABLE_ORIG_DELINQ_DTE", "datetime", 1)
        ("RECEIVABLE_ORIG_DUE_DTE", "datetime", 1)
        ("RECEIVABLE_ORIG_ISSUE_DTE", "datetime", 1)
        ("RECEIVABLE_ORIG_TO_DTE", "datetime", 1)
        ("RECEIVABLE_SETTLEMENT_DTE", "datetime", 1)
        ("RECEIVABLE_STAT", "varchar(40)", 0)
        ("RECEIVABLE_STAT_CHG_DTE", "datetime", 0)
        ("RECEIVABLE_VERS_BILLING_TO_DTE", "datetime", 0)
        ("RECEIVABLE_VERS_DELINQ_DTE", "datetime", 0)
        ("RECEIVABLE_VERS_DUE_DTE", "datetime", 0)
        ("RECEIVABLE_VERS_ISSUE_DTE", "datetime", 0)
        ("RECEIVABLE_VERS_TO_DTE", "datetime", 0)
        ("REG_HOLDER_FLAG", "varchar(1)", 0)
        ("REGION_ID", "varchar(3)", 0)
        ("REGION_NAME", "varchar(20)", 0)
        ("REINSTATEMENT_DTE", "datetime", 1)
        ("RELE_REAL_COVER_ELIG", "varchar(1)", 0)
        ("REND_PENALTY_JURIS_CODE", "varchar(13)", 1)
        ("REND_PENALTY_JURIS_DESCR", "varchar(50)", 0)
        ("RESOLVE_DESCR", "varchar(128)", 0)
        ("RESOLVE_DTE", "datetime", 1)
        ("RESOLVE_RSN", "varchar(40)", 1)
        ("RESOLVED_BY", "varchar(120)", 0)
        ("REVERSAL_DTE", "datetime", 0)
        ("RM_EMP_MSTR_KEY", "varchar(16)", 1)
        ("RM_LOAD_DTE", "datetime", 0)
        ("RM_LOAD_TIME", "varchar(8)", 0)
        ("ROW_CHG_RSN", "varchar(100)", 1)
        ("RSN_INCDT_NOT_BILLED", "varchar(40)", 0)
        ("SAP_BUS_ID", "varchar(20)", 0)
        ("SCHOOL_JURIS_CODE", "varchar(22)", 1)
        ("SCHOOL_JURIS_DESCR", "varchar(50)", 0)
        ("SCND_TEL_NUM", "varchar(16)", 0)
        ("SEN_CITIZEN_FLAG", "varchar(1)", 0)
        ("SIC_CODE", "varchar(8)", 0)
        ("SIC_DIV_CODE", "varchar(20)", 0)
        ("SIC_DIV_NAME", "varchar(40)", 0)
        ("SIC_INDY_GRP_CODE", "varchar(3)", 0)
        ("SIC_INDY_GRP_NAME", "varchar(40)", 0)
        ("SIC_MAJ_GRP_CODE", "varchar(2)", 0)
        ("SIC_MAJ_GRP_NAME", "varchar(40)", 0)
        ("SIC_NAME", "varchar(40)", 0)
        ("SIG_FLAG", "varchar(1)", 0)
        ("SMART_CM_ID", "varchar(20)", 0)
        ("SMARTCM_IS_ADJMT", "varchar(1)", 1)
        ("SMARTCM_IS_FEE", "varchar(1)", 1)
        ("SMARTCM_IS_PAY", "varchar(1)", 1)
        ("SMARTCM_OTHER_CRITERIA", "varchar(50)", 1)
        ("SRC_CARRIER_KEY", "varchar(40)", 0)
        ("SRC_CARRIER_PROCEDURE_KEY", "varchar(40)", 0)
        ("SRC_SYS", "varchar(40)", 0)
        ("SRC_SYS_ID", "varchar(120)", 0)
        ("SRC_SYS_MOD_DTE", "datetime", 1)
        ("SRC_SYS_TRANS_ID", "varchar(40)", 1)
        ("SRC_SYS_VEH_ID", "varchar(32)", 1)
        ("ST", "varchar(60)", 0)
        ("STATE_CORP_CHTR_ID", "varchar(20)", 0)
        ("STATE_FISC_PER", "varchar(15)", 0)
        ("STATE_FISC_PER_NUM", "int", 0)
        ("STATE_FISC_QTR", "varchar(15)", 1)
        ("STATE_FISC_QTR_NUM", "int", 0)
        ("STATE_FISC_YR", "varchar(15)", 1)
        ("STATE_SALES_TAX_ID", "varchar(20)", 0)
        ("SUBSTANTIAL_ERR_PENALTY", "varchar(1)", 0)
        ("SUSPD_PERMIT_DTE", "datetime", 0)
        ("SUSPD_PERMIT_RSN", "varchar(50)", 0)
        ("SYS_LOAD_KEY", "int", 0)
        ("T2_ID", "varchar(20)", 0)
        ("T2_TRANS_MISC_ITEM_CODE", "varchar(20)", 0)
        ("T2_TRANS_MISC_ITEM_DESCR", "varchar(50)", 0)
        ("T2_TRANS_ORIG_OBJ_TYPE_ID", "varchar(10)", 0)
        ("T2_TRANS_PARSED_DESCR", "varchar(50)", 0)
        ("T2_TRANS_RSN", "varchar(50)", 0)
        ("T2_TRANS_SCENARIO", "varchar(50)", 0)
        ("T2_TRANS_TYPE_CODE", "varchar(20)", 0)
        ("T2_TRANS_TYPE_DESCR", "varchar(50)", 0)
        ("TAX_DEFERRAL_END_DTE", "datetime", 0)
        ("TAX_DEFERRAL_START_DTE", "datetime", 0)
        ("TAX_NUM_1", "varchar(16)", 0)
        ("TAX_NUM_2", "varchar(11)", 0)
        ("TAX_ROLL_CODE", "varchar(13)", 1)
        ("TAX_ROLL_DESCR", "varchar(50)", 0)
        ("TAXABLE_PROP_LGL_DESCR_1", "varchar(40)", 0)
        ("TAXABLE_PROP_LGL_DESCR_2", "varchar(40)", 0)
        ("TAXABLE_PROP_LGL_DESCR_3", "varchar(40)", 0)
        ("TAXABLE_PROP_LGL_DESCR_4", "varchar(40)", 0)
        ("TAXABLE_PROP_LGL_DESCR_5", "varchar(40)", 0)
        ("TAXABLE_PROP_ROLL_TYPE", "varchar(50)", 0)
        ("TIME_KEY", "int", 0)
        ("TOWING_CMPNY", "varchar(40)", 0)
        ("TRADING_PRN_ID", "varchar(6)", 0)
        ("TRADING_PRN_NAME", "varchar(30)", 0)
        ("TRANS_AMT", "money", 1)
        ("TRANS_CNT", "int", 1)
        ("TRANS_DTE_KEY", "int", 0)
        ("TXP_SERV_LVL", "varchar(120)", 0)
        ("TXP_TYPE", "varchar(40)", 0)
        ("TYPE_OF_ALM_SITE", "varchar(1)", 0)
        ("UNDER_APPEAL_FLAG", "varchar(1)", 0)
        ("UNIQ_VEND_NAME", "varchar(120)", 1)
        ("UNK_CUST_AT_BILL_FLAG", "varchar(1)", 1)
        ("VAC_FLAG", "varchar(1)", 0)
        ("VALID_FROM_DTE", "datetime", 0)
        ("VALID_TO_DTE", "datetime", 0)
        ("VEH", "varchar(40)", 0)
        ("VEH_COLOR", "varchar(40)", 0)
        ("VEH_ID_NUM", "varchar(24)", 0)
        ("VEH_MAKE", "varchar(40)", 0)
        ("VEH_MODEL", "varchar(40)", 0)
        ("VEH_MODEL_YR", "varchar(4)", 0)
        ("VEH_OWNER_ID", "varchar(32)", 0)
        ("VEH_OWNER_NAME", "varchar(120)", 0)
        ("VEH_TYPE", "varchar(40)", 0)
        ("VEND_BILLER_FLAG", "varchar(1)", 1)
        ("VEND_COLLR_FLAG", "varchar(1)", 1)
        ("VEND_CUST_ID", "varchar(10)", 0)
        ("VEND_CUST_NAME", "varchar(40)", 0)
        ("VEND_FULL_NAME", "varchar(120)", 0)
        ("VEND_GRP_KEY", "varchar(10)", 0)
        ("VEND_ID", "varchar(10)", 0)
        ("VEND_KEY", "int", 0)
        ("VEND_NAME", "varchar(40)", 0)
        ("VEND_NAME_01", "varchar(40)", 0)
        ("VEND_NAME_02", "varchar(40)", 0)
        ("VEND_NAME_03", "varchar(40)", 0)
        ("VEND_NAME_04", "varchar(40)", 0)
        ("VERS_ASSIGNED_VEND", "varchar(120)", 1)
        ("VERS_BEG_DTE", "datetime", 0)
        ("VERS_END_DTE", "datetime", 0)
        ("VIO_CODE", "varchar(20)", 0)
        ("VOID_CODE", "varchar(10)", 0)
        ("VOID_DESCR", "varchar(50)", 0)
        ("VOID_FLAG", "varchar(1)", 0)
        ("WK_IN_CAL_YR", "int", 0)
        ("WKND_FLAG", "varchar(1)", 0)
        ("WORK_STAT", "varchar(50)", 0)
        ("WRITE_OFF_FLAG", "varchar(1)", 0)
        ("WTR_ACCT_NUM_OF_UNITS", "int", 0)
        ("WTR_ACCT_ORIG_USE_TYPE", "varchar(120)", 0)
        ("WTR_ACCT_PROP_USE_TYPE", "varchar(120)", 0)
        ("WTR_METER_NUM", "varchar(50)", 0)
        ("ZIP", "varchar(10)", 0) |]
//"(4) F# FieldDefaults.fsx"
    let fieldDefault = [|
        ("LOAD_DTE"                            , "GETDATE()"   )
        ("LOAD_TIME"                           , "CONVERT(VARCHAR(8),GETDATE(),108)")
        ("VERS_ASSIGNED_VEND"                  , "'CoH'")
        ("MEDICARE_PAYER_CODE"                 , "'(SYS) UNKNOWN'")
        ("MEDICAID_PAYER_CODE"                 , "'(SYS) UNKNOWN'")
        ("CARRIER_FIN_GRP"                     , "'(SYS) UNKNOWN'")
        ("CARRIER_FIN_CLASS"                   , "'(SYS) UNKNOWN'")
        ("CARRIER_GRP"                         , "'(SYS) UNKNOWN'")
        ("CARRIER_NAME"                        , "'(SYS) UNKNOWN'")
        ("SRC_CARRIER_CODE"                    , "'(SYS) UNKNOWN'")
        ("CARRIER_PROCEDURE_CODE"              , "'(SYS) UNKNOWN'")
        ("CARRIER_PROCEDURE_DESCR"             , "'(SYS) UNKNOWN'")
        ("CARRIER_PROCEDURE_TYPE"              , "'(SYS) UNKNOWN'")
        ("CARRIER_PROCEDURE_BILL_CODE"         , "'(SYS) UNKNOWN'")
        ("VEH"                                 , "'(SYS) UNKNOWN'")
        ("EMS_INCDT_CAT"                       , "'(SYS) UNKNOWN'")
        ("ACTV_CARRIER_FIN_GRP"                , "'(SYS) UNKNOWN'")
        ("ACTV_CARRIER_FIN_CLASS"              , "'(SYS) UNKNOWN'")
        ("ACTV_CARRIER"                        , "'(SYS) UNKNOWN'")
        ("NAICS_DET_CODE"                      , "'*'")
        ("NAICS_DIV_CODE"                      , "'*'")
        ("SIC_MAJ_GRP_CODE"                    , "'*'")
        ("DEC_CUST_FLAG"                       , "'*'")
        ("CUST_PREFIX"                         , "'*'")
        ("CUST_SUFF"                           , "'*'")
        ("CUST_GIS_PREFIX"                     , "'*'")
        ("CUST_GIS_SUFF"                       , "'*'")
        ("ALLOC_TRANS_FLAG"                    , "'*'")
        ("SMARTCM_OTHER_CRITERIA"              , "'*'")
        ("SMARTCM_IS_FEE"                      , "'*'")
        ("SMARTCM_IS_ADJMT"                    , "'*'")
        ("SMARTCM_IS_PAY"                      , "'*'")
        ("PERMIT_IS_CURR_AT_TIME_OF_INCDT_FLAG", "'*'")
        ("PRKG_METER_VIO_FLAG"                 , "'*'")
        ("INCDT_PREFIX"                        , "'*'")
        ("INCDT_SUFF"                          , "'*'")
        ("INCDT_IN_CITY_FLAG"                  , "'*'")
        ("INCDT_GIS_PREFIX"                    , "'*'")
        ("INCDT_GIS_SUFF"                      , "'*'")
        ("ITEM_EXMPT_FLAG"                     , "'*'")
        ("ITEM_PREFIX"                         , "'*'")
        ("ITEM_SUFF"                           , "'*'")
        ("ITEM_GIS_PREFIX"                     , "'*'")
        ("ITEM_GIS_SUFF"                       , "'*'")
        ("FIRE_ALM_AGING_RST_FLAG"             , "'*'")
        ("AD_VAL_VET_FLAG"                     , "'*'")
        ("AD_VAL_DISABLED_FLAG"                , "'*'")
        ("AD_VAL_OVER_66_FLAG"                 , "'*'")
        ("AD_VAL_HOMESTEAD_FLAG"               , "'*'")
        ("QTRLY_PAY_FLAG"                      , "'*'")
        ("SRC_CARRIER_KEY"                     , "'***'")
        ("SRC_CARRIER_PROCEDURE_KEY"           , "'***'")
        ("COLL_PERSON_ID"                      , "'***'")
        ("T2_ID"                               , "'***'")
        ("PMAM_ID"                             , "'***'")
        ("SMART_CM_ID"                         , "'***'")
        ("HCTO_AD_VAL_ID"                      , "'***'")
        ("COLL_PERSON_COH_EMP_NUM"             , "'***'")
        ("CUST_EMAIL_ADDR"                     , "'***'")
        ("CUST_PHN_NUM_1"                      , "'***'")
        ("CUST_FAX_NUM"                        , "'***'")
        ("FED_TAX_ID"                          , "'***'")
        ("BUS_CONT_PERSON_NAME"                , "'***'")
        ("STATE_CORP_CHTR_ID"                  , "'***'")
        ("STATE_SALES_TAX_ID"                  , "'***'")
        ("SAP_BUS_ID"                          , "'***'")
        ("NAICS_INDY_CODE"                     , "'***'")
        ("NAICS_INDY_GRP_CODE"                 , "'***'")
        ("NAICS_MAJ_GRP_CODE"                  , "'***'")
        ("SIC_INDY_GRP_CODE"                   , "'***'")
        ("SIC_DIV_CODE"                        , "'***'")
        ("DL_ISSUE_STATE"                      , "'***'")
        ("DL_NUM"                              , "'***'")
        ("CUST_ADDR_LINE_1"                    , "'***'")
        ("CUST_ADDR_LINE_2"                    , "'***'")
        ("CUST_ADDR_LINE_3"                    , "'***'")
        ("CUST_ST_NUM"                         , "'***'")
        ("CUST_ST_PRETYPE"                     , "'***'")
        ("CUST_ST_NAME"                        , "'***'")
        ("CUST_ST_TYPE"                        , "'***'")
        ("CUST_SERV_LVL"                       , "'***'")
        ("CUST_CITY"                           , "'***'")
        ("CUST_STATE"                          , "'***'")
        ("CUST_CTRY"                           , "'***'")
        ("CUST_ST_DIR"                         , "'***'")
        ("CUST_ST"                             , "'***'")
        ("CUST_CNTY"                           , "'***'")
        ("CUST_APT_LOT"                        , "'***'")
        ("CUST_GIS_MATCH_SCORE"                , "'***'")
        ("CUST_GIS_ST_NUM"                     , "'***'")
        ("CUST_GIS_ST_PRETYPE"                 , "'***'")
        ("CUST_GIS_ST_NAME"                    , "'***'")
        ("CUST_GIS_ST_TYPE"                    , "'***'")
        ("CUST_GIS_CITY"                       , "'***'")
        ("CUST_GIS_ZIP"                        , "'***'")
        ("CUST_GIS_X"                          , "'***'")
        ("CUST_GIS_Y"                          , "'***'")
        ("CUST_ZIP_CODE"                       , "'***'")
        ("CUST_ZIP_PLUS_4"                     , "'***'")
        ("CUST_GIS_LOCATR_NAME"                , "'***'")
        ("SIC_CODE"                            , "'***'")
        ("NAICS_DET_NAME"                      , "'***'")
        ("NAICS_INDY_NAME"                     , "'***'")
        ("NAICS_INDY_GRP_NAME"                 , "'***'")
        ("NAICS_MAJ_GRP_NAME"                  , "'***'")
        ("NAICS_DIV_NAME"                      , "'***'")
        ("SIC_NAME"                            , "'***'")
        ("SIC_INDY_GRP_NAME"                   , "'***'")
        ("SIC_MAJ_GRP_NAME"                    , "'***'")
        ("SIC_DIV_NAME"                        , "'***'")
        ("CUST_PHN_NUM_2"                      , "'***'")
        ("CUST_PHN_NUM_3"                      , "'***'")
        ("CUST_PAR_ID"                         , "'***'")
        ("CUST_PAR_NAME"                       , "'***'")
        ("COH_EMP_NUM"                         , "'***'")
        ("RM_LOAD_TIME"                        , "'***'")
        ("RM_EMP_MSTR_KEY"                     , "'***'")
        ("PAY_METH"                            , "'***'")
        ("DET_TRANS_CODE"                      , "'***'")
        ("T2_TRANS_TYPE_CODE"                  , "'***'")
        ("T2_TRANS_TYPE_DESCR"                 , "'***'")
        ("T2_TRANS_RSN"                        , "'***'")
        ("T2_TRANS_PARSED_DESCR"               , "'***'")
        ("T2_TRANS_MISC_ITEM_CODE"             , "'***'")
        ("T2_TRANS_MISC_ITEM_DESCR"            , "'***'")
        ("T2_TRANS_SCENARIO"                   , "'***'")
        ("T2_TRANS_ORIG_OBJ_TYPE_ID"           , "'***'")
        ("PMAM_ADJMT_TO"                       , "'***'")
        ("PMAM_ADJMT_TYPE"                     , "'***'")
        ("DIGITECH_TRANS_TYPE_DET"             , "'***'")
        ("RSN_INCDT_NOT_BILLED"                , "'***'")
        ("VIO_CODE"                            , "'***'")
        ("TOWING_CMPNY"                        , "'***'")
        ("BOOT_SERIAL_NUM"                     , "'***'")
        ("PRKG_METER_NUM"                      , "'***'")
        ("INCDT_SEQ_NUM"                       , "'***'")
        ("INCDT_ADDR_LINE_1"                   , "'***'")
        ("INCDT_ADDR_LINE_2"                   , "'***'")
        ("INCDT_ADDR_LINE_3"                   , "'***'")
        ("INCDT_ST_NUM"                        , "'***'")
        ("INCDT_ST_PRETYPE"                    , "'***'")
        ("INCDT_ST_NAME"                       , "'***'")
        ("INCDT_ST_TYPE"                       , "'***'")
        ("INCDT_SERV_LVL"                      , "'***'")
        ("INCDT_CITY"                          , "'***'")
        ("INCDT_STATE"                         , "'***'")
        ("INCDT_CTRY"                          , "'***'")
        ("INCDT_ST_DIR"                        , "'***'")
        ("INCDT_ST"                            , "'***'")
        ("INCDT_CNTY"                          , "'***'")
        ("INCDT_APT_LOT"                       , "'***'")
        ("INCDT_GIS_MATCH_SCORE"               , "'***'")
        ("INCDT_GIS_ST_NUM"                    , "'***'")
        ("INCDT_GIS_ST_PRETYPE"                , "'***'")
        ("INCDT_GIS_ST_NAME"                   , "'***'")
        ("INCDT_GIS_ST_TYPE"                   , "'***'")
        ("INCDT_GIS_CITY"                      , "'***'")
        ("INCDT_GIS_ZIP"                       , "'***'")
        ("INCDT_GIS_X"                         , "'***'")
        ("INCDT_GIS_Y"                         , "'***'")
        ("INCDT_ZIP_CODE"                      , "'***'")
        ("INCDT_ZIP_PLUS_4"                    , "'***'")
        ("INCDT_GIS_LOCATR_NAME"               , "'***'")
        ("BLK_NUM"                             , "'***'")
        ("TXP_ID"                              , "'***'")
        ("TXP_SERV_LVL"                        , "'***'")
        ("TXP_TYPE"                            , "'***'")
        ("ORIGIN_LOC"                          , "'***'")
        ("DEST_LOC"                            , "'***'")
        ("ITEM_STAT"                           , "'***'")
        ("ITEM_ADDR_LINE_1"                    , "'***'")
        ("ITEM_ADDR_LINE_2"                    , "'***'")
        ("ITEM_ADDR_LINE_3"                    , "'***'")
        ("ITEM_ST_NUM"                         , "'***'")
        ("ITEM_ST_PRETYPE"                     , "'***'")
        ("ITEM_ST_NAME"                        , "'***'")
        ("ITEM_ST_TYPE"                        , "'***'")
        ("ITEM_SERV_LVL"                       , "'***'")
        ("ITEM_CITY"                           , "'***'")
        ("ITEM_STATE"                          , "'***'")
        ("ITEM_CTRY"                           , "'***'")
        ("ITEM_ST_DIR"                         , "'***'")
        ("ITEM_ST"                             , "'***'")
        ("ITEM_CNTY"                           , "'***'")
        ("ITEM_APT_LOT"                        , "'***'")
        ("ITEM_GIS_MATCH_SCORE"                , "'***'")
        ("ITEM_GIS_ST_NUM"                     , "'***'")
        ("ITEM_GIS_ST_PRETYPE"                 , "'***'")
        ("ITEM_GIS_ST_NAME"                    , "'***'")
        ("ITEM_GIS_ST_TYPE"                    , "'***'")
        ("ITEM_GIS_CITY"                       , "'***'")
        ("ITEM_GIS_ZIP"                        , "'***'")
        ("ITEM_GIS_X"                          , "'***'")
        ("ITEM_GIS_Y"                          , "'***'")
        ("ITEM_ZIP_CODE"                       , "'***'")
        ("ITEM_ZIP_PLUS_4"                     , "'***'")
        ("ITEM_GIS_LOCATR_NAME"                , "'***'")
        ("HCAD_ACCT_STAT"                      , "'***'")
        ("AD_VAL_ACCT_LVL_ID"                  , "'***'")
        ("COLL_LGL_COND"                       , "'***'")
        ("COLL_LAWSUIT_NUM"                    , "'***'")
        ("GL_ACCT_ID"                          , "'0000247130'")
        ("INCDT_TIME"                          , "'00:00:00'")
        ("FUND_ID"                             , "'1000'")
        ("EMS_INCDT"                           , "'***'")
        ("DISPATCH_NUM"                        , "'100073'")
        ("FUND_CNTR_ID"                        , "'1200030003'")
        ("CONTR_ID"                            , "'4600012363'")
        ("PT_AGE"                              , "'***'")
        ("BUS_AREA_ID"                         , "'6400'")
        ("RECEIVABLE_STAT"                     , "'ACTIVE'")
        ("DET_TRANS_DESCR"                     , "'Base Amount Billed'")
        ("MSTR_TRANS_TYPE"                     , "'Billed'")
        ("CUST_NAME"                           , "'***'")
        ("ORIG_BILL_NAME"                      , "'***'")
        ("COLL_PERSON_TYPE"                    , "'COH Contractor'")
        ("EMP_NAME"                            , "'***'")
        ("ITEM_TYPE"                           , "'***'")
        ("ITEM_DESCR"                          , "'***'")
        ("INCDT_TYPE"                          , "'***'")
        ("INCDT_CAT"                           , "'***'")
        ("DIV_LONG_NAME"                       , "'***'")
        ("INCDT_DESCR"                         , "'***'")
        ("EMP_TYPE"                            , "'Employee'")
        ("FUNC_AREA_ID"                        , "'GEGO-00-00000000'")
        ("DEPT_LONG_NAME"                      , "'***'")
        ("CUST_TYPE"                           , "'Individual'")
        ("PT_GNDR"                             , "'***'")
        ("COLL_PERSON_NAME"                    , "'Employee'")
        ("DIGITECH_ID"                         , "'***'")
        ("CARRIER_SRC"                         , "'***'")
        ("CARRIER_PROCEDURE_SRC"               , "'***'")
        ("CUST_IS_VEND_FLAG"                   , "'N'")
        ("JV_CUST_FLAG"                        , "'N'")
        ("MAN_TRANS_FLAG"                      , "'N'")
        ("DERIVED_TRANS_FLAG"                  , "'N'")
        ("INTRA_FUND_TRANS_FLAG"               , "'N'")
        ("ADJ_FLAG"                            , "'N'")
        ("UNK_CUST_AT_BILL_FLAG"               , "'N'")
        ("BILLING_HOLD_FLAG"                   , "'N'")
        ("SIG_FLAG"                            , "'N'")
        ("RECEIVABLE_MSTR_STAT"                , "'Open'")
        ("DIGITECH_TRANS_TYPE"                 , "'PROCS'")
        ("INT_EXT_EMP_FLAG"                    , "'Y'")
        ("CONFI_CUST_FLAG"                     , "'Y'")
        ("CUST_IN_CITY_FLAG"                   , "'Y'")
        ("BILLED_FLAG"                         , "'Y'")
        ("ITEM_IN_CITY_FLAG"                   , "'Y'")
        ("RECEIVABLE_EVER_TRANS_FLAG"          , "'Y'")
        ("CUST_PAR_KEY"                        , "1")
        ("TRANS_CNT"                           , "1")
        ("SRC_SYS_MOD_DTE"                     , "'1900-01-01'")
        ("RM_LOAD_DTE"                         , "'1900-01-01'")
        ("ITEM_STAT_CHG_DTE"                   , "'1900-01-01'")
        ("RECEIVABLE_STAT_CHG_DTE"             , "'1900-01-01'")
        ("FIRE_ORIG_ISSUE_DTE"                 , "'1900-01-01'")
        ("RECEIVABLE_MSTR_STAT_CHG_DTE"        , "'1900-01-01'")
        ("AD_VAL_TAX_DEFERRAL_START_DTE"       , "'1900-01-01'")
        ("AD_VAL_TAX_DEFERRAL_END_DTE"         , "'1900-01-01'")
        ("AD_VAL_EFF_DTE_OF_OWNERSHIP"         , "'1900-01-01'")
        ("3348_ATTY_FEE_DTE"                   , "'1900-01-01'")
        ("3308_ATTY_FEE_DTE"                   , "'1900-01-01'")
        ("3307_ATTY_FEE_DTE"                   , "'1900-01-01'")
        ("RECEIVABLE_VERS_DELINQ_DTE"          , "'1900-01-01'")
        ("RECEIVABLE_VERS_DUE_DTE"             , "'1900-01-01'")
        ("RECEIVABLE_VERS_TO_DTE"              , "'1900-01-01'")
        ("RECEIVABLE_VERS_BILLING_TO_DTE"      , "'1900-01-01'")
        ("INCDT_DTE"                           , "'1900-01-01'")
        ("RECEIVABLE_VERS_ISSUE_DTE"           , "'1900-01-01'")
        ("INTRA_FUND_TRANS_AMT"                , "NULL"        )
        ("RECEIVABLE_1ST_PAY_DTE"              , "'1900-01-01'")
        ("RECEIVABLE_FNL_PAY_DTE"              , "'1900-01-01'")
        ("RECEIVABLE_LITIGATION_DTE"           , "'1900-01-01'")
        ("RECEIVABLE_SETTLEMENT_DTE"           , "'1900-01-01'")
        ("REINSTATEMENT_DTE"                   , "'1900-01-01'")
        ("SRC_SYS_TRANS_ID"                    , "'***'"       )
    
        ("ALLOWABLE_NO_CHRG_INCDTS"            , "0"           )
        ("ALM_INSTL_CMPNY"                     , "'***'"       )
        ("ALM_INSTL_DTE"                       , "'1900-01-01'")
        ("ALM_MNT_CMPNY"                       , "'***'"       )
        ("ALM_REG_KEY"                         , "'***'"       )
        ("ALM_TYPE"                            , "'*'"         )
        ("APPLICTN_RECV_DTE"                   , "'1900-01-01'")
        ("APPRAISAL_DISTR_ACCT_NUM"            , "'***'"       )
        ("CC_JURIS_DESCR"                      , "'***'"       )
        ("CITY_RFPD_JURIS_DESCR"               , "'***'"       )
        ("CURR_FIRE_ALM_PERMIT_FLAG"           , "'*'"         )
        ("CURR_WTR_ACCT_FLAG"                  , "'*'"         )
        ("CUST_ID"                             , "'***'"       )
        ("DELINQ_DTE"                          , "'1900-01-01'")
        ("DTE"                                 , "'1900-01-01'")
        ("ESC_CAND_FLAG"                       , "'*'"         )
        ("EXCL_TYPE"                           , "'***'"       )
        ("FIRE_ALM_PERMIT_ACTV_FLAG"           , "'*'"         )
        ("FIRE_ALM_PERMIT_NUM"                 , "'***'"       )
        ("FIRE_ALM_PURPOSE"                    , "'***'"       )
        ("INV_NUM"                             , "'***'"       )
        ("LAST_CUST_CONN_DTE"                  , "'1900-01-01'")
        ("LAST_CUST_CUTOFF_DTE"                , "'1900-01-01'")
        ("LAST_CUST_DISCONN_DTE"               , "'1900-01-01'")
        ("LAST_METER_INSPECT_DTE"              , "'1900-01-01'")
        ("LICENSE_PLATE_EXP_MTH"               , "'***'"       )
        ("LICENSE_PLATE_EXP_YR"                , "'***'"       )
        ("LICENSE_PLATE_NUM"                   , "'***'"       )
        ("LICENSE_PLATE_TYPE"                  , "'***'"       )
        ("MUNIC_UTIL_DISTR_DESCR"              , "'***'"       )
        ("ON_ADMIN_HOLD_FLAG"                  , "'*'"         )
        ("OWNERSHIP_EFF_DTE"                   , "'1900-01-01'")
        ("OWNER_IS_CUST_FLAG"                  , "'*'"         )
        ("OWNER_RENTER"                        , "'*'"         )
        ("PERMIT_EXP_DTE"                      , "'1900-01-01'")
        ("PERMIT_ISSUE_DTE"                    , "'1900-01-01'")
        ("PERMIT_NAME"                         , "'***'"       )
        ("PERMIT_NUM"                          , "0"           )
        ("PROP_CLASS_DESCR"                    , "'***'"       )
        ("RECEIVABLE_HAS_LTR_FLAG"             , "'*'"         )
        ("RECEIVABLE_HAS_NOTE_FLAG"            , "'*'"         )
        ("RECEIVABLE_HAS_PEND_LTR_FLAG"        , "'*'"         )
        ("REG_HOLDER_FLAG"                     , "'*'"         )
        ("REND_PENALTY_JURIS_DESCR"            , "'***'"       )
        ("RESOLVED_BY"                         , "'***'"       )
        ("RESOLVE_DESCR"                       , "'***'"       )
        ("SCHOOL_JURIS_DESCR"                  , "'***'"       )
        ("SEN_CITIZEN_FLAG"                    , "'*'"         )
        ("SRC_SYS"                             , "'***'"       )
        ("SRC_SYS_ID"                          , "'***'"       )
        ("SUBSTANTIAL_ERR_PENALTY"             , "'*'"         )
        ("SUSPD_PERMIT_DTE"                    , "'1900-01-01'")
        ("SUSPD_PERMIT_RSN"                    , "'***'"       )
        ("TAXABLE_PROP_LGL_DESCR_1"            , "'***'"       )
        ("TAXABLE_PROP_LGL_DESCR_2"            , "'***'"       )
        ("TAXABLE_PROP_LGL_DESCR_3"            , "'***'"       )
        ("TAXABLE_PROP_LGL_DESCR_4"            , "'***'"       )
        ("TAXABLE_PROP_LGL_DESCR_5"            , "'***'"       )
        ("TAXABLE_PROP_ROLL_TYPE"              , "'***'"       )
        ("TAX_DEFERRAL_END_DTE"                , "'1900-01-01'")
        ("TAX_DEFERRAL_START_DTE"              , "'1900-01-01'")
        ("TAX_ROLL_DESCR"                      , "'***'"       )
        ("TYPE_OF_ALM_SITE"                    , "'*'"         )
        ("UNDER_APPEAL_FLAG"                   , "'*'"         )
        ("VAC_FLAG"                            , "'*'"         )
        ("VEH_COLOR"                           , "'***'"       )
        ("VEH_ID_NUM"                          , "'***'"       )
        ("VEH_MAKE"                            , "'***'"       )
        ("VEH_MODEL"                           , "'***'"       )
        ("VEH_MODEL_YR"                        , "'***'"       )
        ("VEH_OWNER_ID"                        , "'***'"       )
        ("VEH_OWNER_NAME"                      , "'***'"       )
        ("VEH_TYPE"                            , "'***'"       )
        ("VOID_CODE"                           , "'***'"       )
        ("VOID_DESCR"                          , "'***'"       )
        ("VOID_FLAG"                           , "'*'"         )
        ("WORK_STAT"                           , "'***'"       )
        ("WRITE_OFF_FLAG"                      , "'*'"         )
        ("WTR_ACCT_NUM_OF_UNITS"               , "0"           )
        ("WTR_ACCT_ORIG_USE_TYPE"              , "'***'"       )
        ("WTR_ACCT_PROP_USE_TYPE"              , "'***'"       )
        ("WTR_METER_NUM"                       , "'***'"       )
    
    |]
//"(4) F# SlowlyChangingDimensions.fsx"
    open System.Text.RegularExpressions
    open Microsoft.FSharp.Reflection
    
    module Option =
        let defaultValue: 'a -> 'a option -> 'a = 
            fun           dv    aO        ->
                match aO with
                | None   -> dv
                | Some v -> v
    
    let padName: int -> string -> string =
             fun len    name   -> name.PadRight len
    
    let pad4 = padName 40
    let pad2 = padName 20
    
    let defaultValue v opt = match opt with
                             | Some x -> x
                             | None   -> v
    
    let aNumeral (s : string) = if s.StartsWith "A#" then s.[2..] else s
    
    let toString (x:'a) = 
        match FSharpValue.GetUnionFields(x, typeof<'a>) with
        | case, _ -> case.Name
        |> aNumeral
    
    let fromString<'a> (s:string) =
        match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
        |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
        |_ -> None
    
    type sqlObjectType = | PROCEDURE | VIEW | TRIGGER
    with
         member this.Name      = toString this
         member this.Condition = match    this with
                                 | PROCEDURE -> "IN ( N'P', N'PC' )"
                                 | VIEW      -> "=    N'V' "
                                 | TRIGGER   -> "=    N'TR'"
    
    let sqlDropCreate: sqlObjectType -> string -> string =
                   fun sqlType          name   -> sprintf """
    IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'%s') AND type %s)
        DROP %s %s;
    GO
    -- Machine-generated-code, DO NOT MODIFY HERE
    -- %s 'HPL', '2017-03-01'
    CREATE %s %s
    """                                                name         sqlType.Condition 
                                                       sqlType.Name name 
                                                       name 
                                                       sqlType.Name name
    
    
    let regexIdentifier = Regex @"^[\p{L}_][\p{L}\p{N}@$#_]{0,127}$|^\[.+\]$"
                                                    
    let isIdentifier: string -> bool =
                  fun txt    -> regexIdentifier.IsMatch txt
    
    let nameS fName = 
        if isIdentifier fName 
        then fName 
        else sprintf "[%s]" fName
    
    type TargetField
    with
         member this.Name = toString this
    
    type FinTransViewField
    with
         member this.Name = toString this
    
    type Field =
        | SurrogateKey   of TargetField
        | BusinessKey    of FinTransViewField
        | SourceDate     of FinTransViewField
        | IntraDayOrder  of  FinTransViewField
        | SCD2BeginDate  of TargetField
        | SCD2EndDate    of TargetField
        | SCD2Current    of TargetField
        | ChangeReason   of TargetField
        | SCD2           of FinTransViewField * scd1:TargetField option * scd0:TargetField option /// Version  value
        | SCD1           of FinTransViewField * scd0:TargetField option                           /// Current  value
        | SCD0           of FinTransViewField                               /// SCD0 without accompanying SCD1 or 2
    with member this.Name0 = 
            match this with
            | SurrogateKey   tfield
            | SCD2BeginDate  tfield
            | SCD2EndDate    tfield
            | ChangeReason   tfield
            | SCD2Current    tfield        -> tfield.Name
            | BusinessKey    sfield
            | SourceDate     sfield
            | IntraDayOrder  sfield
            | SCD2          (sfield, _, _) 
            | SCD1          (sfield, _   ) 
            | SCD0           sfield        -> sfield.Name
         member this.Name = this.Name0 |> nameS
    
    let strOption: string -> string option =
               fun txt    -> match txt.Trim() with
                             | "" -> None
                             | f  -> Some f
    
    let tfldOption: TargetField -> TargetField option =
                fun fld         -> match fld with | Nil  -> None | _ -> Some fld
    
    let sfldOption: FinTransViewField -> FinTransViewField option =
                fun fld         -> match fld with | Nil_ -> None | _ -> Some fld
    
    let SurrogateKey  name           : Field =  name                   |> SurrogateKey 
    let BusinessKey   name           : Field =  name                   |> BusinessKey  
    let SourceDate    name           : Field =  name                   |> SourceDate   
    let IntraDayOrder name           : Field =  name                   |> IntraDayOrder   
    let SCD2BeginDate name           : Field =  name                   |> SCD2BeginDate
    let SCD2EndDate   name           : Field =  name                   |> SCD2EndDate  
    let SCD2Current   name           : Field =  name                   |> SCD2Current  
    let ChangeReason  name           : Field =  name                   |> ChangeReason  
    let SCD0          name           : Field =  name                   |> SCD0         
    let SCD1          name      scd0 : Field = (name, tfldOption scd0) |> SCD1         
    let SCD2          name scd1 scd0 : Field = (name, tfldOption scd1                   
                                                    , tfldOption scd0) |> SCD2
        
    let fieldNames      :  Field -> string list =
                       fun f     -> match f with 
                                    | SCD2         (_, Some scd1, Some scd0) -> [ f.Name ; scd1.Name ; scd0.Name ]
                                    | SCD2         (_, _        , Some scd0) -> [ f.Name             ; scd0.Name ]
                                    | SCD1         (_,            Some scd0) -> [ f.Name             ; scd0.Name ]
                                    | _                                      -> [ f.Name                         ]
    
    let fieldSource     :  Field -> string list =
                       fun f     -> match f with 
                                    | SurrogateKey  _
                                    | SCD2BeginDate _
                                    | SCD2EndDate   _
                                    | ChangeReason  _
                                    | SCD2Current   _            -> []
                                    | _                          -> [ f.Name ]
    
    let fieldTarget    :  Field -> string list =
                       fun f     -> match f with 
                                    | SurrogateKey  tfield
                                    | SCD2BeginDate tfield
                                    | SCD2EndDate   tfield
                                    | ChangeReason  tfield
                                    | SCD2Current   tfield                   -> [ tfield.Name            ]
                                    | SCD2         (_, Some scd1, Some scd0) -> [ scd1  .Name ; scd0.Name]
                                    | SCD2         (_, _        , Some scd0) -> [               scd0.Name]
                                    | SCD1         (_,            Some scd0) -> [               scd0.Name]
                                    | _                                      -> []
    
    let fieldAlias      :  Field -> string =
                       fun f     -> match f with 
                                    | SurrogateKey  _ -> "SurrogateKey_ "
                                    | BusinessKey   _ -> "BusinessKey_  "
                                    | SourceDate    _ -> "SourceDate_   "
                                    | IntraDayOrder _ -> "IntraDayOrder_"
                                    | SCD2BeginDate _ -> "SourceDate_   "
                                    | ChangeReason  _
                                    | SCD2Current   _ 
                                    | SCD2EndDate   _ -> "" 
                                    | _               -> f.Name
    let fieldAliasValue :  Field -> string -> string = 
                       fun f        v      -> sprintf "%s = %s" (pad4 (fieldAlias f)) v
    
    let fieldSelectTable:  Field -> string list =
                       fun f     -> match f with 
                                    | SurrogateKey  _ -> [ fieldAliasValue f f.Name ]
                                    | BusinessKey   _ -> [ fieldAliasValue f f.Name ]
                                    | SCD2BeginDate _ -> [ fieldAliasValue f f.Name ]
                                    | SourceDate    _ 
                                    | IntraDayOrder _
                                    | ChangeReason  _
                                    | SCD2Current   _ 
                                    | SCD2EndDate   _ -> [] 
                                    | _               -> [ f.Name ]
    
    let fieldSelectSource: (string -> string) -> Field -> string list =
                       fun transform             f     ->
                                    match f with 
                                    | SurrogateKey  _ -> [ fieldAliasValue f "NULL"  ]
                                    | BusinessKey   _ -> [ fieldAliasValue f f.Name ]
                                    | SourceDate    _ -> [ fieldAliasValue f f.Name ]
                                    | IntraDayOrder _
                                    | SCD2BeginDate _
                                    | ChangeReason  _
                                    | SCD2Current   _ 
                                    | SCD2EndDate   _ -> []
                                    | _               -> [ transform f.Name ]
    
    let fieldSelectTogether1: (string -> string) -> Field -> string list =
                       fun    transform             f     ->
                                    match f with 
                                    | SurrogateKey  _ -> [ fieldAlias f |> transform ]
                                    | BusinessKey   _ -> [ fieldAlias f              ]
                                    | SourceDate    _ -> [ fieldAlias f              ]
                                    | IntraDayOrder _
                                    | SCD2BeginDate _ 
                                    | ChangeReason  _
                                    | SCD2Current   _ 
                                    | SCD2EndDate   _ -> []
                                    | _               -> [ transform f.Name ]
    
    let fieldInsert     :  Field -> string list =
                       fun f     -> match f with 
                                    | SourceDate    _ 
                                    | IntraDayOrder _
                                    | SurrogateKey  _ -> []
                                    | _               -> fieldNames f
    
    let fieldValues     :  Field -> string list =
                       fun f     -> match f with 
                                    | SourceDate    _ 
                                    | IntraDayOrder _
                                    | SurrogateKey  _ -> []
                                    | _               -> fieldNames f |> List.map (sprintf "S.%s")
    
    let fieldUpdate     :  Field -> string list =
                       fun f     -> match f with 
                                    | SourceDate    _ 
                                    | IntraDayOrder _
                                    | BusinessKey   _
                                    | SurrogateKey  _ -> []
                                    | _               -> fieldNames f |> List.map (fun n -> sprintf "T.%s = S.%s" (pad4 n) n)
    
    let fieldSCD2Equal   : Field -> string list =
                       fun f     -> match f with 
                                    | SCD2 _ -> [ sprintf "S.%s = P.%s" ( pad4 f.Name) f.Name ]
                                    | _      -> []
                                    
    let fieldSCD2        : Field -> string list =
                       fun f     -> match f with 
                                    | SCD2 _             -> [ sprintf "S.%s" f.Name ]
                                    | _                  -> []
    
    let fieldSCD0        : Field -> string list =
                       fun f     -> match f with 
                                    | SCD1(_,    Some scd0) 
                                    | SCD2(_, _, Some scd0) -> [ sprintf "%s = FIRST_VALUE(S.%s) OVER (PARTITION BY S.BusinessKey_ ORDER BY S.NRec_)" (pad4 scd0.Name) f.Name ]
                                    | SCD0 _                -> [ sprintf "%s = FIRST_VALUE(S.%s) OVER (PARTITION BY S.BusinessKey_ ORDER BY S.NRec_)" (pad4 f.Name   ) f.Name ]
                                    | _                     -> []
    
    let fieldSCD1        : Field -> string list =
                       fun f     -> match f with 
                                    | SCD2(_, Some scd1, _) -> [ sprintf "%s = LAST_VALUE(S.%s ) OVER (PARTITION BY S.BusinessKey_ ORDER BY S.NRec_ ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING)" (pad4 scd1.Name) f.Name ]
                                    | SCD1 _                -> [ sprintf "%s = LAST_VALUE(S.%s ) OVER (PARTITION BY S.BusinessKey_ ORDER BY S.NRec_ ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING)" (pad4 f.Name   ) f.Name ]
                                    | _                     -> []
    
    type SQLTableView = {
        db       : string option
        schema   : string option
        sqlObject: string
        where    : string option
        parms    : string option
    }
    with member this.Reference   : string =
                                   match this.db, this.schema with
                                   | None   , None    -> sprintf "%s"
                                   | Some db, None    -> sprintf "%s..%s"   (nameS db)
                                   | Some db, Some sc -> sprintf "%s.%s.%s" (nameS db) (nameS sc)
                                   | None   , Some sc -> sprintf "%s.%s"               (nameS sc)
                                   <| nameS this.sqlObject
         member this.Call        : string =
                                   match this.parms with
                                   | None    -> sprintf "%s"
                                   | Some ps -> fun r -> sprintf "%s(%s)" r ps
                                   <| this.Reference
         member this.FromWhere   : string =
                                   match this.where with
                                   | None    -> sprintf "%s"
                                   | Some wh -> fun c -> sprintf "%s WHERE %s " c wh
                                   <| this.Call
    
         static member New: string -> string ->  string  -> string -> string -> SQLTableView =
                        fun db        schema     sobject    where     parms  -> {
                                                                                    db        = strOption db
                                                                                    schema    = strOption schema
                                                                                    sqlObject = sobject.Trim()
                                                                                    where     = strOption where 
                                                                                    parms     = strOption parms
                                                                                }
    
    let indent : string  -> string =
             fun content -> content.Split[| '\n' |] |> String.concat "\n    "
    
    let indent2: string  -> string =
             fun content -> "    " + (indent content)
    
    type SQLWith = { 
        name   : string 
        content: string 
    }
    with override this.ToString()  = sprintf "%s as (\n%s\n)" this.name this.content
         static member New: string -> string  -> SQLWith =
                        fun name      content -> { name = name.Trim() ; content = indent2 content }
    
    let sqlSelectP: string -> string -> string seq -> string =
        fun         select    from      fields     -> 
            fields 
            |> String.concat "\n     , "
            |> sprintf "%s %s\n  FROM %s" select <| from
    
    let sqlSelect : string -> string seq -> string = sqlSelectP "SELECT"
    let sqlSelectD: string -> string seq -> string = sqlSelectP "SELECT Distinct"
    
    let sqlProcedure: string -> string  -> string  -> string=
                  fun name      parms      content -> 
                      sqlDropCreate PROCEDURE name
                      |> sprintf "%s %s\n as \n %s \nGO" <| parms <| content
    
    let bSurrogateKey  = function | SurrogateKey  _ -> true | _ -> false
    let bBusinessKey   = function | BusinessKey   _ -> true | _ -> false
    let bSourceDate    = function | SourceDate    _ -> true | _ -> false
    let bIntraDayOrder = function | IntraDayOrder _ -> true | _ -> false
    let bSCD2BeginDate = function | SCD2BeginDate _ -> true | _ -> false
    let bSCD2EndDate   = function | SCD2EndDate   _ -> true | _ -> false
    let bChangeReason  = function | ChangeReason  _ -> true | _ -> false
    let bSCD2Current   = function | SCD2Current   _ -> true | _ -> false
    let bSCD2          = function | SCD2          _ -> true | _ -> false
    
    type Dimension( tableBase : SQLTableView
                  , source    : SQLTableView
                  , fields    : Field  seq
                  , snowflakes: string seq
                  , extra     : Printf.StringFormat<_>) =
         let isSnowflaked   = snowflakes |> Seq.isEmpty |> not
         let countF filter  = fields |> Seq.filter filter |> Seq.length
         let cSurrogateKey  = countF bSurrogateKey 
         let cBusinessKey   = countF bBusinessKey  
         let cSourceDate    = countF bSourceDate   
         let cIntraDayOrder = countF bIntraDayOrder
         let cSCD2BeginDate = countF bSCD2BeginDate
         let cSCD2EndDate   = countF bSCD2EndDate  
         let cChangeReason  = countF bChangeReason  
         let cSCD2Current   = countF bSCD2Current  
         let cSCD2          = countF bSCD2
         let table          = if isSnowflaked then { tableBase with sqlObject = "SV_" + tableBase.sqlObject } else tableBase
         let duplicates     = fields |> Seq.collect fieldNames |> Seq.countBy (fun n -> n.Trim().ToUpper()) |> Seq.choose (fun (n, i) -> if i > 1 then sprintf "Field %s appears more than once" n |> Some else None) |> Seq.toList
         let errors         = [
                                 if              cSurrogateKey  = 0 then yield "A SurrogateKey  must be specified"
                                 if              cBusinessKey   = 0 then yield "A BusinessKey   must be specified"
                                 if cSCD2 > 0 && cSourceDate    = 0 then yield "A SourceDate    must be specified"
                                 if cSCD2 > 0 && cIntraDayOrder = 0 then yield "A IntraDayOrder must be specified"
                                 if cSCD2 > 0 && cSCD2BeginDate = 0 then yield "A SCD2BeginDate must be specified"
                                 if cSCD2 > 0 && cSCD2EndDate   = 0 then yield "A SCD2EndDate   must be specified"
                                 if              cSurrogateKey  > 1 then yield "Only 1 SurrogateKey  can be specified"
                                 if              cBusinessKey   > 1 then yield "Only 1 BusinessKey   can be specified"
                                 if              cSourceDate    > 1 then yield "Only 1 SourceDate    can be specified"
                                 if              cIntraDayOrder > 1 then yield "Only 1 IntraDayOrder can be specified"
                                 if              cSCD2BeginDate > 1 then yield "Only 1 SCD2BeginDate can be specified"
                                 if              cSCD2EndDate   > 1 then yield "Only 1 SCD2EndDate   can be specified"
                                 if              cSCD2Current   > 1 then yield "Only 1 SCD2Current   can be specified"
                                 if              cChangeReason  > 1 then yield "Only 1 ChangeReason  can be specified"
                                 if cSCD2 = 0 && cSourceDate    = 1 then yield "No SCD2 fields, SourceDate    cannot be specified"
                                 if cSCD2 = 0 && cIntraDayOrder = 1 then yield "No SCD2 fields, IntraDayOrder cannot be specified"
                                 if cSCD2 = 0 && cSCD2BeginDate = 1 then yield "No SCD2 fields, SCD2BeginDate cannot be specified"
                                 if cSCD2 = 0 && cSCD2EndDate   = 1 then yield "No SCD2 fields, SCD2EndDate   cannot be specified"
                                 if cSCD2 = 0 && cSCD2Current   = 1 then yield "No SCD2 fields, SCD2Current   cannot be specified"
                              ] @ duplicates
         do if not errors.IsEmpty then failwith (errors |> String.concat "\n")
         let find  : (Field -> bool) -> string =
                 fun  ft             -> fields |> Seq.find ft |> fun f -> f.Name
         let surrogateKey   = find bSurrogateKey
         let businessKey    = find bBusinessKey
         let sourceDateO    = if cSourceDate    = 1 then find bSourceDate    |> Some else None
         let intraDayOrderO = if cIntraDayOrder = 1 then find bIntraDayOrder |> Some else None
         let sCD2BeginDateO = if cSCD2BeginDate = 1 then find bSCD2BeginDate |> Some else None
         let sCD2EndDateO   = if cSCD2EndDate   = 1 then find bSCD2EndDate   |> Some else None
         let sCD2CurrentO   = if cSCD2Current   = 1 then find bSCD2Current   |> Some else None
         let changeReasonO  = if cChangeReason  = 1 then find bChangeReason  |> Some else None 
         let procedureName  = sprintf "GENERIC.SP_LOAD_%s" table.sqlObject
         let lastOfDay    n = sprintf "%s = LAST_VALUE(%s) OVER (PARTITION BY %s, %s ORDER BY %s ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING)" (pad4 n) n businessKey (sourceDateO |> Option.defaultValue "") (intraDayOrderO |> Option.defaultValue "")
         let together1    n = sprintf "%s = LAST_VALUE(%s) OVER (PARTITION BY BusinessKey_, SourceDate_ ORDER BY SurrogateKey_ ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING)" (pad4 n) n 
    with
         new(table, source, fields            ) = Dimension(table, source, fields, []        , "%s")
         new(table, source, fields, snowflakes) = Dimension(table, source, fields, snowflakes, "%s")
         member this.TableReference     = table    .Reference
         member this.TableBase          = tableBase
         member this.Fields: (Field -> string list) -> string seq =
                         fun chooser                  -> fields |> Seq.sort |> Seq.collect chooser
         member this.AllFields          = this.Fields <| fieldNames
         member this.FinTransViewFields = this.Fields <| fieldSource
         member this.TargetFields       = this.Fields <| fieldTarget
         member this.Existing           = this.Fields <| fieldSelectTable
         member this.Source             = this.Fields <| fieldSelectSource    (if cSCD2 > 0 then lastOfDay else id)
         member this.Together1          = this.Fields <| fieldSelectTogether1 (if cSCD2 > 0 then together1 else id)
         member this.Together2          = [
                                            sprintf "NRec_  = ROW_NUMBER() OVER (PARTITION BY BusinessKey_ ORDER BY %s)" <| if cSCD2 > 0 then "SourceDate_, ISNULL(SurrogateKey_, 2147483647)" else "ISNULL(SurrogateKey_, 2147483647)"
                                            "*"
                                          ]
         member this.NewRec             = if cSCD2 > 0 then 
                                              this.Fields fieldSCD2Equal
                                              |> String.concat "\n                 AND "  
                                              |> sprintf "NewRec_ = IIF (%s, 0, 1)"
                                           else          "NewRec_ = IIF (P.BusinessKey_ is NULL                  , 1, 0) "
         member this.Ordered            = [
                                            yield                    "S.SurrogateKey_ "
                                            yield                    "S.BusinessKey_  "
                                            yield                    "S.NRec_         "
                                            yield                    this.NewRec      
                                            if cSCD2 > 0 then yield  "S.SourceDate_   "
                                            yield!                   this.Fields fieldSCD2
                                            yield!                   this.Fields fieldSCD1
                                            yield!                   this.Fields fieldSCD0
                                          ]
         member this.SCD2Records        = [
                                            "SCD2Record_ = SUM(NewRec_    ) OVER (PARTITION BY BusinessKey_ ORDER BY NRec_ ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)"
                                            "NextDate_   = MAX(SourceDate_) OVER (PARTITION BY BusinessKey_ ORDER BY NRec_ ROWS BETWEEN CURRENT ROW AND 1 FOLLOWING)"
                                            "LastRec_    = MAX(NRec_      ) OVER (PARTITION BY BusinessKey_)"
                                            "*"
                                          ]
         member this.VersBeg            = [
                                            sCD2BeginDateO.Value |> pad4 |> sprintf "%s = MIN(SourceDate_) OVER (PARTITION BY BusinessKey_, SCD2Record_)"
                                            sCD2EndDateO  .Value |> pad4 |> sprintf "%s = DATEADD(d, -1, MAX(IIF(NRec_ = LastRec_, '9999-12-31', NextDate_)) OVER (PARTITION BY BusinessKey_, SCD2Record_))"
                                            "*"
                                          ]
         member this.RKeys              = [
                                            if sCD2CurrentO.IsSome then 
                                               yield sCD2CurrentO.Value  |> pad4 |> sprintf "%s = IIF(%s = '9999-12-30', 'Y', 'N')"                       <| sCD2EndDateO.Value
                                            yield    surrogateKey        |> pad4 |> sprintf "%s = MAX(SurrogateKey_) OVER (PARTITION BY BusinessKey_ %s)" <| if sCD2BeginDateO.IsSome  then  ", " + sCD2BeginDateO.Value else ""
                                            yield    businessKey         |> pad4 |> sprintf "%s = BusinessKey_"
                                            if changeReasonO.IsSome then
                                               yield changeReasonO.Value |> pad4 |> sprintf "%s = '---'"
                                            yield    "*"
                                          ]
         member this.fromTogether2      = "    Together2 S
     LEFT JOIN Together2 P ON P.BusinessKey_ = S.BusinessKey_
                          AND P.NRec_        = S.NRec_ - 1"
         member this.Withs              =
             [
                 yield    SQLWith.New "Existing     " <| sqlSelect  table .FromWhere              this.Existing 
                 yield    SQLWith.New "Source       " <| sqlSelectD source.FromWhere              this.Source   
                 yield    SQLWith.New "Together0    " <| "SELECT *  FROM Existing UNION ALL SELECT * FROM Source"
                 yield    SQLWith.New "Together1    " <| sqlSelectD "Together0"                   this.Together1
                 yield    SQLWith.New "Together2    " <| sqlSelect  "Together1          "         this.Together2
                 yield    SQLWith.New "Ordered      " <| sqlSelect  this.fromTogether2            this.Ordered     
                 if cSCD2 > 0 then                                  
                    yield SQLWith.New "SCD2Records  " <| sqlSelect  "Ordered            "         this.SCD2Records 
                    yield SQLWith.New "VersBeg      " <| sqlSelect  "SCD2Records        "         this.VersBeg     
                    yield SQLWith.New "RKeys        " <| sqlSelect  "VersBeg            "         this.RKeys     
                 else                                               
                    yield SQLWith.New "RKeys        " <| sqlSelect  "Ordered            "         this.RKeys     
             ]
         member this.LastWith           = this.Withs |> Seq.last
         member this.SelectIntoTemp     = if isSnowflaked then sprintf "    , NewSurrogateKey_ = NEXT VALUE FOR Seq_%s\n" this.TableBase.sqlObject else ""
                                          |> sprintf "SELECT * \n%s   INTO #TEMP\n  FROM %s \n WHERE NewRec_ = 1" <| this.LastWith.name                                       
         member this.Insert             = this.Fields fieldInsert
                                          |> String.concat "\n, "
                                          |> sprintf "   INSERT(%s %s)" (if isSnowflaked then sprintf "%s\n," surrogateKey  else "")
                                          |> indent  |> indent
         member this.Values             = this.Fields fieldValues
                                          |> String.concat "\n, "
                                          |> sprintf "   VALUES(%s %s)\n" (if isSnowflaked then "NewSurrogateKey_\n," else "")
                                          |> indent  |> indent
         member this.Update             = this.Fields fieldUpdate
                                          |> String.concat "\n, "
                                          |> indent |> indent
         member this.WhenNotMatched     = sprintf "WHEN NOT MATCHED BY TARGET THEN\n%s\n%s" 
                                          <| this.Insert            <| this.Values
         member this.WhenMatched        = (fun f -> if f <> "" then sprintf "WHEN MATCHED THEN\nUPDATE SET %s" f else f)
                                          <| this.Update
         member this.Merge              = sprintf "MERGE %s AS T\nUSING #TEMP AS S\nON (T.%s = S.%s)\n%s\n%s;" 
                                          <| this.TableReference 
                                          <| surrogateKey        <| surrogateKey
                                          <| this.WhenNotMatched
                                          <| this.WhenMatched
         member this.Query              = this.Withs
                                          |> List.map (fun w -> w.ToString())
                                          |> String.concat ", "
                                          |> sprintf "WITH %s"
                                          |> sprintf "%s \n%s; \n%s" <| this.SelectIntoTemp <| this.Merge
         member this.Procedure          = this.Query
                                          |> sprintf "BEGIN\n  EXEC GENERIC.Log @SOURCE, '%s', 'Started Merge', '';\n  %s\n END\n" procedureName
                                          |> sqlProcedure procedureName "@SOURCE VARCHAR(30), @CURRENT_DTE DATE = NULL" 
         member this.ProcedureName      = procedureName
         member this.SurrogateKey       = surrogateKey
         member this.BusinessKey        = businessKey
         member this.SourceDateO        = sourceDateO
         member this.SCD2BeginDateO     = sCD2BeginDateO
         member this.SCD2EndDateO       = sCD2EndDateO  
         member this.TableName          = table.sqlObject
         member this.Verification       = sCD2BeginDateO 
                                          |> Option.map (fun b ->
                                                let e = sCD2EndDateO.Value
                                                sprintf " AND (D.%s BETWEEN X.%s AND X.%s  OR D.%s BETWEEN X.%s AND X.%s ) " b b e  e b e
                                             )
                                          |> defaultValue ""
                                          |> sprintf "SELECT * \n  FROM %s D \n WHERE EXISTS(SELECT * \n         FROM %s X \n      WHERE X.%s <> D.%s AND X.%s = D.%s %s) \n ORDER BY %s %s" 
                                                table.Reference table.Reference
                                                surrogateKey    surrogateKey    
                                                businessKey     businessKey
                                          <| businessKey <| ""
         member this.Snowflakes         = snowflakes
                                          
                                        
    type FactField = 
        | Fact   of FinTransViewField
        | OField of TargetField * value: string
    
    let OField: TargetField -> string -> FactField = 
            fun fld            value  -> (fld, value.Trim()) |> OField
    
    [< NoComparison >]
    type DimRef =
        | DimRef of Dimension * SurrogateKey: TargetField option * BusinesKey: FinTransViewField option
    with
         member this.Dim                = match this with                                      DimRef (dim, _   , _) -> dim
         member this.FactSurrogateKey   = match this with | DimRef (dim, Some key, _) -> key.Name | DimRef (dim, None, _) -> dim.SurrogateKey
         member this.FactBusinessKey    = match this with | DimRef (dim, _, Some key) -> key.Name | DimRef (dim, _, None) -> dim.BusinessKey
         member this.FinTransViewFields = match this with | DimRef (dim, sKO, bKO) -> seq [ yield! bKO |> Option.map (fun f -> f.Name) |> Option.toList ; yield! dim.FinTransViewFields ]
         member this.TargetFields       = match this with | DimRef (dim, sKO, bKO) -> seq [ yield! sKO |> Option.map (fun f -> f.Name) |> Option.toList ; yield! dim.TargetFields       ]
         static member New dim                             = DimRef(dim, None             , None            )
         static member New(dim, surrogateKey             ) = DimRef(dim, Some surrogateKey, None            )
         static member New(dim, surrogateKey, businessKey) = DimRef(dim, Some surrogateKey, Some businessKey)
    let dimension: Dimension -> TargetField -> FinTransViewField -> DimRef = 
               fun dim          surroK         businK      -> DimRef (dim, tfldOption surroK, sfldOption businK)
    
    type FactTable( table  : SQLTableView
                  , source : SQLTableView
                  , dims   : DimRef    seq
                  , fields : FactField seq
                  , extra  : Printf.StringFormat<_>) =
         let procedureName  = sprintf "GENERIC.SP_LOAD_%s" table.sqlObject
    with 
         member this.SourceFields   = fields 
                                      |> Seq.map (function 
                                                  | Fact f       -> f.Name
                                                  | OField(_, f) -> f
                                                 )
                                      |> Seq.append (dims |> Seq.collect (function dimR -> dimR.FinTransViewFields))
                                      |> Seq.distinct
         member this.TargetFields   = fields 
                                      |> Seq.collect (function 
                                                      | Fact f       -> []
                                                      | OField(f, _) -> [ f.Name ]
                                                     )
                                      |> Seq.append (dims |> Seq.collect (function dimR -> dimR.TargetFields))
                                      |> Seq.distinct
         member this.Keys           = dims |> Seq.mapi(fun i dim -> sprintf "D%d.%s" i dim.Dim.SurrogateKey)
         member this.Joins          = dims 
                                      |> Seq.mapi(fun i dim -> 
                                                        dim.Dim.SourceDateO
                                                        |> Option.map (fun v -> sprintf " AND S.%s BETWEEN D%d.%s AND D%d.%s" v i dim.Dim.SCD2BeginDateO.Value i dim.Dim.SCD2EndDateO.Value)
                                                        |> defaultValue ""
                                                        |> sprintf "%s D%d ON D%d.%s = S.%s %s" (pad2 dim.Dim.TableBase.Reference) i i (pad2 dim.Dim.BusinessKey) (pad2 dim.FactBusinessKey)
                                                 )
                                      |> Seq.toList                                                                 
         member this.From           = sprintf "%s S" source.FromWhere
                                      :: this.Joins
                                      |> String.concat "\n LEFT JOIN "
         member this.Query          = fields 
                                      |> Seq.map (function 
                                                  | Fact   f     -> sprintf "S.%s"    f.Name
                                                  | OField(f, v) -> sprintf "%s = %s" (pad2 f.Name) v
                                                 )
                                      |> Seq.append this.Keys 
                                      |> sqlSelect this.From
         member this.InsertFields   = fields 
                                      |> Seq.map (function 
                                                  | Fact f       -> f.Name
                                                  | OField(f, _) -> f.Name
                                                 )
                                      |> Seq.append (dims |> Seq.map (fun dim -> dim.FactSurrogateKey))
                                      |> String.concat "\n     , "
         member this.Insert         = sprintf "INSERT INTO %s\n      (%s)\n%s" table.Reference this.InsertFields this.Query
                                      |> sprintf extra
         member this.Procedure      = sqlProcedure procedureName "@SOURCE VARCHAR(30), @FROM DATE = NULL, @TO DATE = NULL" this.Insert
    
    let print: string -> unit =
           fun txt    -> printf "\n\n%s\n\n" txt
    
    let FinTransViewFields: FactTable -> Dimension seq -> string seq =
        fun                 fTable       dims          -> 
            fTable.SourceFields 
            |> Seq.append     (dims |> Seq.collect (fun dim -> dim.FinTransViewFields))
            |> Seq.filter     isIdentifier
            |> Seq.distinctBy (fun f -> f.ToUpper())
            |> Seq.sort
    
    let targetFields: FactTable -> Dimension seq -> string seq =
        fun           fTable       dims          -> 
            fTable.TargetFields 
            |> Seq.append     (dims |> Seq.collect (fun dim -> dim.TargetFields))
            |> Seq.filter     isIdentifier
            |> Seq.distinctBy (fun f -> f.ToUpper())
            |> Seq.sort
    
    
    let getDecl: string -> (string * bool) option =
             fun fname  -> fieldDecl
                           |> Seq.choose (fun (name, typeDecl, nullable) -> if name = fname.ToUpper() then (typeDecl, nullable = 1) |> Some else None)
                           |> Seq.tryHead
    
    let getDefault: string -> string option =
                fun fname  -> fieldDefault
                              |> Array.tryPick (fun (name, value) -> if name = fname.ToUpper() then Some value else None)
    
    let convert fName v =
        getDecl fName 
        |> Option.map (fun (fType, nullable) -> fType.Trim())
        |> Option.map (fun typeName -> sprintf "CONVERT(%s, %s)"  typeName v) 
        |> Option.defaultValue v
    
    let applyDefault fName v =
        getDecl fName 
        |> Option.bind (fun (fType, nullable) ->
               if nullable then None
               else getDefault fName
               |> Option.map (sprintf "ISNULL(%s, %s)" v)
        )
        |> Option.defaultValue v
    
    let equalField fName v =
        fName
        |> nameS
        |> pad4 
        |> sprintf "%s = %s"  <| v
    
    type FinTransViewField
    with 
        
        member this.Convert      v = convert      this.Name v
        member this.applyDefault v = applyDefault this.Name v
        member this.equal        v = equalField   this.Name v
        member this.DefaultO       = getDefault   this.Name
    
    let cast: FinTransViewField -> string -> string =
          fun field                value  ->
              value
              |> field.Convert
              |> field.applyDefault 
              |> field.equal
    
    type QueryField(target: FinTransViewField, value: string) =
        let name = target.Name
    with
        member this.Entry = cast target value
        member this.Name  = name
    
    let vwField: FinTransViewField -> string -> QueryField = 
             fun fld                  value  -> QueryField(fld, value.Trim())
    
    
    let inline getUnionNames typ =
        Microsoft.FSharp.Reflection.FSharpType.GetUnionCases typ
        |> Seq.map (fun e -> e.Name |> aNumeral)
        |> Seq.filter ((<>)"Nil_")
        |> Seq.sort
        |> Seq.toArray
    
    let finTransViewFieldNames = getUnionNames typeof<FinTransViewField>
    let targetFieldNames   = getUnionNames typeof<TargetField>
    
    let missingFields: QueryField seq -> string[] =
        fun            fields         -> 
            finTransViewFieldNames
            |> Array.filter (fun e -> fields |> Seq.exists (fun f -> f.Name = e) |> not)
    
    let allFields() = missingFields (seq[])
                      |> Seq.sort
                      |> String.concat "\n        , "
    
    let setDefault: string -> string =
                fun field  -> getDefault    field 
                              |> Option.defaultValue "(NULL)" 
                              |> convert    field
                              |> equalField field
    
    type FactView(name: SQLTableView, source: SQLTableView, fields: QueryField seq) =
        let fieldsCached = fields |> Seq.toArray
        let getFieldValue fName =
            fieldsCached 
            |> Array.tryFind      (fun q -> q.Name    = fName)
            |> Option.map         (fun q -> q.Entry          )
            |> Option.defaultWith (fun _ -> setDefault  fName)
    with
         member this.Query = finTransViewFieldNames 
                             |> Array.map  getFieldValue
                             |> String.concat "\n        , "
                             |> sprintf "SELECT %s\n FROM %s;\n" <| source.FromWhere
                             |> sprintf "%s\n as %s; \nGO" (sqlDropCreate VIEW name.Call)
    
    let missingDefaults() =
        finTransViewFieldNames 
        |> Seq.map    (fun n -> n, getDecl n, getDefault n)
        |> Seq.filter (fun (n, typeO, defO) -> 
             match typeO, defO with
             | None               , _
             | Some (_    , false), None -> true
             | _                         -> false
        )
        |> Seq.map     (fun (n, typO, _) ->
            (n, typO, 
                match typO with
                | Some("int"       , _) -> "0"
                | Some("varchar(1)", _)
                | Some("varchar(2)", _) -> "'*'"
                | Some("date"      , _) 
                | Some("datetime"  , _) -> "'1900-01-01'"
                | _                     -> "'***'"
            )
        )
    
    let missingDecls () =
        fieldDecl
        |> Array.filter(fun (n, typ, nullable) -> Seq.exists ((=)n) finTransViewFieldNames |> not)
        |> Array.filter(fun (n, typ, nullable) -> Seq.exists ((=)n) finTransViewFieldNames |> not)
        
    
    let inline str4 s = s |> sprintf "%A" |> pad4 
    let inline str2 s = s |> sprintf "%A" |> pad2 
    
    (*          
    (*keep*)#load "BetterFSI.fsx"  // <<<==== Execute first in F# Interactive
    Do __SOURCE_FILE__ __LINE__ //
    Do __SOURCE_FILE__ __LINE__ //  missingDecls()    |> Seq.iter (printfn "%A")
    Do __SOURCE_FILE__ __LINE__ //  missingDefaults() |> Seq.iter (printfn "%A")
    Do __SOURCE_FILE__ __LINE__ //  missingDefaults() |> Seq.iter (fun (n, _, d) -> printfn "(%s, %s)" (str4 n) (str2 d))
    Do __SOURCE_FILE__ __LINE__ //  finTransViewFieldNames |> Seq.filter (fun a -> a.StartsWith "A#" ) |>
    *)
    
//"(4) F# dimReceivable.fsx"
    let dimReceivable = 
        Dimension(
            table  = SQLTableView.New "         " "       " "DIM_RECEIVABLE        " "SRC_SYS_ID LIKE @SOURCE + '%'" ""
          , source = SQLTableView.New "         " "       " "FINTRANS              " "" ""
          , snowflakes =
                     [
                        "DIM_RECEIVABLE_AD_VAL_RECEIVABLE_DET"
                        "DIM_RECEIVABLE_BOOT_TOW_DET"
                        "DIM_RECEIVABLE_EMS_RECEIVABLE_DET"
                        "DIM_RECEIVABLE_FIRE_ALM_CIT_DET"
                        "DIM_RECEIVABLE_PRKG_CONTRA_DET"
                     ]
          , fields = [
                        BusinessKey    SRC_SYS_ID                     
                        SourceDate     DTE
                        IntraDayOrder  INTRA_DAY_ORDER
                        ChangeReason   ROW_CHG_RSN
                        
                        SurrogateKey   RECEIVABLE_KEY                    
                        SCD2BeginDate  VERS_BEG_DTE                       
                        SCD2EndDate    VERS_END_DTE                       
                        SCD2Current    CURR_VERS_FLAG           
    
    ////////////                       SCD2                              SCD1                             SCD0        
    ////////////                       ---------                         -------                          ------
                        SCD2           RECEIVABLE_STAT                   Nil                              Nil
                        SCD2           RECEIVABLE_STAT_CHG_DTE           Nil                              Nil
                        SCD2           RECEIVABLE_VERS_ISSUE_DTE         RECEIVABLE_CURR_ISSUE_DTE        RECEIVABLE_ORIG_ISSUE_DTE            
                        SCD2           RECEIVABLE_VERS_DUE_DTE           RECEIVABLE_CURR_DUE_DTE          RECEIVABLE_ORIG_DUE_DTE              
                        SCD2           RECEIVABLE_VERS_DELINQ_DTE        RECEIVABLE_CURR_DELINQ_DTE       RECEIVABLE_ORIG_DELINQ_DTE           
                        SCD2           RECEIVABLE_VERS_TO_DTE            RECEIVABLE_CURR_TO_DTE           RECEIVABLE_ORIG_TO_DTE               
                        SCD2           RECEIVABLE_VERS_BILLING_TO_DTE    RECEIVABLE_CURR_BILLING_TO_DTE   RECEIVABLE_ORIG_BILLING_TO_DTE       
                        SCD2           VERS_ASSIGNED_VEND                CURR_ASSIGNED_VEND               ORIG_ASSIGNED_VEND              
                        SCD2           RECEIVABLE_MSTR_STAT              Nil                              Nil
                        SCD2           RECEIVABLE_MSTR_STAT_CHG_DTE      Nil                              Nil
    
    ////////////                       SCD1                              SCD0                    
    ////////////                       ---------                         -------                        
                        SCD1           INV_NUM                           ORIG_INV_NUM                   
                        SCD1           RECEIVABLE_EVER_TRANS_FLAG        Nil
                        SCD1           RECEIVABLE_LITIGATION_DTE         Nil
                        SCD1           RECEIVABLE_FNL_PAY_DTE            Nil
                        SCD1           RECEIVABLE_1ST_PAY_DTE            Nil
                        SCD1           RECEIVABLE_SETTLEMENT_DTE         Nil
                        SCD1           FIRE_ALM_AGING_RST_FLAG           Nil
                        SCD1           REINSTATEMENT_DTE                 Nil
                        SCD1           FIRE_ORIG_ISSUE_DTE               Nil
                        SCD1           ITEM_DESCR                        Nil
                        SCD1           ORIG_BILL_NAME                    Nil
                        SCD1           UNK_CUST_AT_BILL_FLAG             Nil
    
    ////////////                       SCD0                    
    ////////////                       --------- 
                        SCD0           LOAD_DTE                        
                        SCD0           LOAD_TIME              
                        
                        SCD1           FLAG_DIM_RECEIVABLE_AD_VAL_RECEIVABLE_DET  Nil
                        SCD1           ``A#3307_ATTY_FEE_DTE``                    Nil
                        SCD1           ``A#3308_ATTY_FEE_DTE``                    Nil
                        SCD1           ``A#3348_ATTY_FEE_DTE``                    Nil
                        SCD1           AD_VAL_ACCT_LVL_ID                         Nil
                        SCD1           AD_VAL_DISABLED_FLAG                       Nil
                        SCD1           AD_VAL_EFF_DTE_OF_OWNERSHIP                Nil
                        SCD1           AD_VAL_HOMESTEAD_FLAG                      Nil
                        SCD1           AD_VAL_OVER_66_FLAG                        Nil
                        SCD1           AD_VAL_TAX_DEFERRAL_END_DTE                Nil
                        SCD1           AD_VAL_TAX_DEFERRAL_START_DTE              Nil
                        SCD1           AD_VAL_VET_FLAG                            Nil
                        SCD1           COLL_LAWSUIT_NUM                           Nil
                        SCD1           COLL_LGL_COND                              Nil
                        SCD1           HCAD_ACCT_STAT                             Nil
                        SCD1           QTRLY_PAY_FLAG                             Nil
                        SCD1           FLAG_DIM_RECEIVABLE_BOOT_TOW_DET           Nil
                        SCD1           RECEIVABLE_HAS_LTR_FLAG                    Nil
                        SCD1           RECEIVABLE_HAS_NOTE_FLAG                   Nil
                        SCD1           RECEIVABLE_HAS_PEND_LTR_FLAG               Nil
                        SCD1           RESOLVE_DESCR                              Nil
                        SCD1           RESOLVE_DTE                                Nil
                        SCD1           RESOLVE_RSN                                Nil
                        SCD1           RESOLVED_BY                                Nil
                        SCD1           FLAG_DIM_RECEIVABLE_EMS_RECEIVABLE_DET     Nil
                        SCD1           ACTV_CARRIER                               Nil
                        SCD1           ACTV_CARRIER_FIN_CLASS                     Nil
                        SCD1           ACTV_CARRIER_FIN_GRP                       Nil
                        SCD1           BILLING_HOLD_FLAG                          Nil
                        SCD1           SIG_FLAG                                   Nil
                        SCD1           FLAG_DIM_RECEIVABLE_FIRE_ALM_CIT_DET       Nil
                        SCD1           VOID_CODE                                  Nil
                        SCD1           VOID_DESCR                                 Nil
                        SCD1           WORK_STAT                                  Nil
                        SCD1           FLAG_DIM_RECEIVABLE_PRKG_CONTRA_DET        Nil
                        SCD1           ESC_CAND_FLAG                              Nil
                        SCD1           ON_ADMIN_HOLD_FLAG                         Nil
                        SCD1           UNDER_APPEAL_FLAG                          Nil
                        SCD1           VOID_FLAG                                  Nil
                        SCD1           WRITE_OFF_FLAG                             Nil
                     ]
        )
    //dimReceivable.Query |> System.Windows.Forms.Clipboard.SetText
    (*
    open SlowlyChangingDimensions
    print dimReceivable.Procedure
    print dimReceivable.Verification
    *)
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ServiceNow.Models
{
    public class IncidentPostResponse
    {
        
        [JsonProperty("caused_by")]
        public string CausedBy { get; set; }

        [JsonProperty("u_service_desk")]
        public string UServiceDesk { get; set; }

        [JsonProperty("watch_list")]
        public string WatchList { get; set; }

        [JsonProperty("upon_reject")]
        public string UponReject { get; set; }

        [JsonProperty("sys_updated_on")]
        public DateTimeOffset SysUpdatedOn { get; set; }

        [JsonProperty("approval_history")]
        public string ApprovalHistory { get; set; }

        [JsonProperty("u_ci_not_found")]
        public bool UCiNotFound { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("u_sender_email")]
        public string USenderEmail { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("sys_created_by")]
        public string SysCreatedBy { get; set; }

        [JsonProperty("knowledge")]
        
        public bool Knowledge { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("u_break_fix")]
        public bool UBreakFix { get; set; }

        [JsonProperty("u_knowledge_used")]
        public string UKnowledgeUsed { get; set; }

        [JsonProperty("cmdb_ci")]
        public string CmdbCi { get; set; }

        [JsonProperty("impact")]
        public long Impact { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("work_notes_list")]
        public string WorkNotesList { get; set; }

        [JsonProperty("u_inc_please_specify")]
        public string UIncPleaseSpecify { get; set; }

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("sys_domain_path")]
        public string SysDomainPath { get; set; }

        [JsonProperty("business_duration")]
        public string BusinessDuration { get; set; }

        [JsonProperty("group_list")]
        public string GroupList { get; set; }

        [JsonProperty("u_assignment_group_count")]
        public long UAssignmentGroupCount { get; set; }

        [JsonProperty("approval_set")]
        public string ApprovalSet { get; set; }

        [JsonProperty("u_inc_external_ticket_number")]
        public string UIncExternalTicketNumber { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("correlation_display")]
        public string CorrelationDisplay { get; set; }

        [JsonProperty("work_start")]
        public string WorkStart { get; set; }

        [JsonProperty("additional_assignee_list")]
        public string AdditionalAssigneeList { get; set; }

        [JsonProperty("u_inbound_email_recipients")]
        public string UInboundEmailRecipients { get; set; }

        [JsonProperty("u_inc_external_ticket_system")]
        public string UIncExternalTicketSystem { get; set; }

        [JsonProperty("notify")]
        public long Notify { get; set; }

        [JsonProperty("sys_class_name")]
        public string SysClassName { get; set; }

        [JsonProperty("closed_by")]
        public string ClosedBy { get; set; }

        [JsonProperty("follow_up")]
        public string FollowUp { get; set; }

        [JsonProperty("parent_incident")]
        public string ParentIncident { get; set; }

        [JsonProperty("reassignment_count")]
        public long ReassignmentCount { get; set; }

        [JsonProperty("u_number_and_type_of_users_impacted")]
        public string UNumberAndTypeOfUsersImpacted { get; set; }

        [JsonProperty("assigned_to")]
        public string AssignedTo { get; set; }

        [JsonProperty("sla_due")]
        public string SlaDue { get; set; }

        [JsonProperty("u_outage_end")]
        public string UOutageEnd { get; set; }

        [JsonProperty("comments_and_work_notes")]
        public string CommentsAndWorkNotes { get; set; }

        [JsonProperty("u_uc_last_name")]
        public string UUcLastName { get; set; }

        [JsonProperty("u_uc_phone_number")]
        public string UUcPhoneNumber { get; set; }

        [JsonProperty("escalation")]
        public long Escalation { get; set; }

        [JsonProperty("upon_approval")]
        public string UponApproval { get; set; }

        [JsonProperty("correlation_id")]
        public string CorrelationId { get; set; }

        [JsonProperty("made_sla")]
        
        public bool MadeSla { get; set; }

        [JsonProperty("u_major_incident")]
        
        public bool UMajorIncident { get; set; }

        [JsonProperty("child_incidents")]
        public long ChildIncidents { get; set; }

        [JsonProperty("hold_reason")]
        public string HoldReason { get; set; }

        [JsonProperty("resolved_by")]
        public string ResolvedBy { get; set; }

        [JsonProperty("sys_updated_by")]
        public string SysUpdatedBy { get; set; }

        [JsonProperty("opened_by")]
        public ResourceLink OpenedBy { get; set; }

        [JsonProperty("user_input")]
        public string UserInput { get; set; }

        [JsonProperty("sys_created_on")]
        public DateTimeOffset SysCreatedOn { get; set; }

        [JsonProperty("u_no_kb_article")]
        public bool UNoKbArticle { get; set; }

        [JsonProperty("sys_domain")]
        public ResourceLink SysDomain { get; set; }

        [JsonProperty("u_ext_support")]
        public bool UExtSupport { get; set; }

        [JsonProperty("u_drag_screen_shots_here")]
        public string UDragScreenShotsHere { get; set; }

        [JsonProperty("calendar_stc")]
        public string CalendarStc { get; set; }

        [JsonProperty("closed_at")]
        public string ClosedAt { get; set; }

        [JsonProperty("u_concise_incident_description_including_symptom_details")]
        public string UConciseIncidentDescriptionIncludingSymptomDetails { get; set; }

        [JsonProperty("u_application_s_and_business_function_s_impacted")]
        public string UApplicationSAndBusinessFunctionSImpacted { get; set; }

        [JsonProperty("business_service")]
        public string BusinessService { get; set; }

        [JsonProperty("rfc")]
        public string Rfc { get; set; }

        [JsonProperty("time_worked")]
        public string TimeWorked { get; set; }

        [JsonProperty("expected_start")]
        public string ExpectedStart { get; set; }

        [JsonProperty("opened_at")]
        public string OpenedAt { get; set; }

        [JsonProperty("u_uc_first_name")]
        public string UUcFirstName { get; set; }

        [JsonProperty("u_unknown_caller")]
        public bool UUnknownCaller { get; set; }

        [JsonProperty("work_end")]
        public string WorkEnd { get; set; }

        [JsonProperty("caller_id")]
        public string CallerId { get; set; }

        [JsonProperty("resolved_at")]
        public string ResolvedAt { get; set; }

        [JsonProperty("u_new_ci")]
        public string UNewCi { get; set; }

        [JsonProperty("u_incident_first_reported_by")]
        public string UIncidentFirstReportedBy { get; set; }

        [JsonProperty("subcategory")]
        public string Subcategory { get; set; }

        [JsonProperty("work_notes")]
        public string WorkNotes { get; set; }

        [JsonProperty("close_code")]
        public string CloseCode { get; set; }

        [JsonProperty("assignment_group")]
        public string AssignmentGroup { get; set; }

        [JsonProperty("business_stc")]
        public string BusinessStc { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("calendar_duration")]
        public string CalendarDuration { get; set; }

        [JsonProperty("u_outage_start")]
        public string UOutageStart { get; set; }

        [JsonProperty("close_notes")]
        public string CloseNotes { get; set; }

        [JsonProperty("u_is_revenue_impacted")]
        public string UIsRevenueImpacted { get; set; }

        [JsonProperty("sys_id")]
        public string SysId { get; set; }

        [JsonProperty("u_priority_setting_and_explanation")]
        public string UPrioritySettingAndExplanation { get; set; }

        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("u_regulatory_item")]
        
        public bool URegulatoryItem { get; set; }

        [JsonProperty("incident_state")]
        public string IncidentState { get; set; }

        [JsonProperty("urgency")]
        public long Urgency { get; set; }

        [JsonProperty("problem_id")]
        public string ProblemId { get; set; }

        [JsonProperty("u_chg_planned_start")]
        public string UChgPlannedStart { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("activity_due")]
        public string ActivityDue { get; set; }

        [JsonProperty("severity")]
        public long Severity { get; set; }

        [JsonProperty("u_regulatory_agency")]
        public string URegulatoryAgency { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("approval")]
        public string Approval { get; set; }

        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        [JsonProperty("sys_mod_count")]
        public long SysModCount { get; set; }

        [JsonProperty("reopen_count")]
        public long ReopenCount { get; set; }

        [JsonProperty("sys_tags")]
        public string SysTags { get; set; }

        [JsonProperty("u_uc_email")]
        public string UUcEmail { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("u_inc_line_of_business")]
        public string UIncLineOfBusiness { get; set; }
    }
}

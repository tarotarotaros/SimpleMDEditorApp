namespace SimpleMDEditorApp
{
    public enum ProposalStatusType
    {
        None,
        Proposal,
    }


    public class ProposalStatus
    {
        public ProposalStatusType Type => _proposalStatus;
        public string ProposalText => _proposalText;

        private readonly ProposalStatusType _proposalStatus;
        private readonly string _proposalText;

        public ProposalStatus(ProposalStatusType proposalStatusType, string proposalText)
        {
            _proposalStatus = proposalStatusType;
            _proposalText = proposalText;
        }
    }
}

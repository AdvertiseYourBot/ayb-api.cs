namespace AybApiTest
{
    class Stats
    {
        public int Bots;
        public int PendingApprovals;
        public int UnreadReports;

        public Stats(int bots, int pendingApprovals, int unreadReports)
        {
            Bots = bots;
            UnreadReports = unreadReports;
            PendingApprovals = pendingApprovals;
        }
    }
}

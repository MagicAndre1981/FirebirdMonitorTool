﻿using System;
using System.Collections.Generic;
using System.Linq;
using FirebirdMonitorTool.Attachment;
using FirebirdMonitorTool.Context;
using FirebirdMonitorTool.Function;
using FirebirdMonitorTool.Procedure;
using FirebirdMonitorTool.Statement;
using FirebirdMonitorTool.Transaction;
using FirebirdMonitorTool.Trigger;
using NUnit.Framework;

namespace FirebirdMonitorTool.Tests
{
    public class ProfilerTreeBuilderTests
    {
        [Test]
        public void Test01()
        {
            var data = new[]
            {
@"2021-04-27T19:16:32.1570 (30360:000000010DAB0E40) TRACE_INIT",
@"	SESSION_1 FOO",
@"	",
@"",
@"2021-04-27T19:16:32.1570 (30360:000000010DAB0E40) ATTACH_DATABASE",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"",
@"2021-04-27T19:16:32.1630 (30360:000000010DAB0E40) START_TRANSACTION",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) PREPARE_STATEMENT",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Statement 131773:",
@"-------------------------------------------------------------------------------",
@"execute procedure sync_mark_last_sync(1, ?)",
@"     32 ms",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_STATEMENT_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Statement 131773:",
@"-------------------------------------------------------------------------------",
@"execute procedure sync_mark_last_sync(1, ?)",
@"",
@"param0 = timestamp, ""2021-04-27T18:16:31.7930""",
@"",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_PROCEDURE_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Procedure SYNC_MARK_LAST_SYNC:",
@"param0 = bigint, ""1""",
@"param1 = timestamp, ""2021-04-27T18:16:31.7930""",
@"",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_ONLY_SYS_INIT FOR T_NODE (BEFORE UPDATE) ",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_ONLY_SYS_INIT FOR T_NODE (BEFORE UPDATE) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_UPD FOR T_NODE (BEFORE UPDATE) ",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_PROCEDURE_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Procedure INT_VERSIONING_START:",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_FUNCTION_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.VERSION_START:",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_FUNCTION_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.CS_VERSION_START:",
@"param0 = varchar(1024), ""E:\DB\XXX\XXX.FDB""",
@"param1 = bigint, ""265639""",
@"",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_FUNCTION_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.CS_VERSION_START:",
@"param0 = varchar(1024), ""E:\DB\XXX\XXX.FDB""",
@"param1 = bigint, ""265639""",
@"",
@"returns:",
@"param0 = bigint, ""13264181467023000""",
@"",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_FUNCTION_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.VERSION_START:",
@"returns:",
@"param0 = bigint, ""13264181467023000""",
@"",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) SET_CONTEXT",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"[USER_TRANSACTION] CTX_VERSION = ""13264181467023000""",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_PROCEDURE_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Procedure INT_VERSIONING_START:",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_UPD FOR T_NODE (BEFORE UPDATE) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_ONLY_SYS_INIT_UPD FOR T_NODE (BEFORE UPDATE) ",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_ONLY_SYS_INIT_UPD FOR T_NODE (BEFORE UPDATE) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	X_ND_UPD_DEF FOR T_NODE (BEFORE UPDATE) ",
@"",
@"2021-04-27T19:16:32.1960 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	X_ND_UPD_DEF FOR T_NODE (BEFORE UPDATE) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	W_ND_UPD FOR T_NODE (AFTER UPDATE) ",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	W_ND_UPD FOR T_NODE (AFTER UPDATE) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_REBUILD_SEARCH FOR T_NODE (AFTER UPDATE) ",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	T_ND_REBUILD_SEARCH FOR T_NODE (AFTER UPDATE) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	X_ND_UPD FOR T_NODE (AFTER UPDATE) ",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	X_ND_UPD FOR T_NODE (AFTER UPDATE) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_PROCEDURE_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Procedure SYNC_MARK_LAST_SYNC:",
@"param0 = bigint, ""1""",
@"param1 = timestamp, ""2021-04-27T18:16:31.7930""",
@"",
@"      0 ms, 42 fetch(es), 4 mark(s)",
@"",
@"Table                             Natural     Index    Update    Insert    Delete   Backout     Purge   Expunge",
@"***************************************************************************************************************",
@"RDB$INDICES                                       8                                                            ",
@"T_NODE                                            1         1                                                  ",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) EXECUTE_STATEMENT_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Statement 131773:",
@"-------------------------------------------------------------------------------",
@"execute procedure sync_mark_last_sync(1, ?)",
@"",
@"param0 = timestamp, ""2021-04-27T18:16:31.7930""",
@"",
@"0 records fetched",
@"      0 ms, 42 fetch(es), 4 mark(s)",
@"",
@"Table                             Natural     Index    Update    Insert    Delete   Backout     Purge   Expunge",
@"***************************************************************************************************************",
@"RDB$INDICES                                       8                                                            ",
@"T_NODE                                            1         1                                                  ",
@"",
@"2021-04-27T19:16:32.1970 (30360:000000010DAB0E40) FREE_STATEMENT",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"",
@"Statement 131773:",
@"-------------------------------------------------------------------------------",
@"execute procedure sync_mark_last_sync(1, ?)",
@"",
@"2021-04-27T19:16:32.2280 (30360:000000010DAB0E40) EXECUTE_TRIGGER_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	DBCOMMITRANSACTION (ON TRANSACTION_COMMIT) ",
@"",
@"2021-04-27T19:16:32.2280 (30360:000000010DAB0E40) EXECUTE_FUNCTION_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.VERSION_STOP_SEED:",
@"param0 = bigint, ""13264181467023000""",
@"",
@"",
@"2021-04-27T19:16:32.2280 (30360:000000010DAB0E40) EXECUTE_FUNCTION_START",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.CS_VERSION_STOP_SEED:",
@"param0 = varchar(1024), ""E:\DB\XXX\XXX.FDB""",
@"param1 = bigint, ""13264181467023000""",
@"param2 = bigint, ""265639""",
@"",
@"",
@"2021-04-27T19:16:32.2280 (30360:000000010DAB0E40) EXECUTE_FUNCTION_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.CS_VERSION_STOP_SEED:",
@"param0 = varchar(1024), ""E:\DB\XXX\XXX.FDB""",
@"param1 = bigint, ""13264181467023000""",
@"param2 = bigint, ""265639""",
@"",
@"returns:",
@"param0 = bigint, ""-1""",
@"",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.2280 (30360:000000010DAB0E40) EXECUTE_FUNCTION_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"",
@"Function INTERNALS.VERSION_STOP_SEED:",
@"param0 = bigint, ""13264181467023000""",
@"",
@"returns:",
@"param0 = bigint, ""-1""",
@"",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.2280 (30360:000000010DAB0E40) EXECUTE_TRIGGER_FINISH",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"	DBCOMMITRANSACTION (ON TRANSACTION_COMMIT) ",
@"      0 ms",
@"",
@"2021-04-27T19:16:32.2470 (30360:000000010DAB0E40) COMMIT_TRANSACTION",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"		(TRA_265639, READ_COMMITTED | REC_VERSION | NOWAIT | READ_WRITE)",
@"     19 ms, 5 write(s), 1 fetch(es), 1 mark(s)",
@"",
@"2021-04-27T19:16:32.2470 (30360:000000010DAB0E40) DETACH_DATABASE",
@"	E:\DB\XXX\XXX.FDB (ATT_262220, CLIENT:NONE, UTF8, TCPv4:127.0.0.1/56680)",
@"	E:\www\www.com\:12040",
@"",
@"2021-04-27T19:16:32.2490 (30360:000000010DAB0E40) TRACE_FINI",
@"	SESSION_1 FOO",
            };

            var nodes = new List<ProfilerTreeBuilder.Node>();
            var builder = new ProfilerTreeBuilder();
            builder.OnNode += (sender, node) => nodes.Add(node);
            foreach (var item in data.Select(x => x + Environment.NewLine))
                builder.Process(item);
            builder.Flush();
            Assert.AreEqual(1, nodes.Count);
            Assert.AreEqual(2, nodes[0].Count);
            Assert.IsTrue(nodes[0][0].Command.GetType().IsAssignableTo(typeof(IAttachmentStart)));
            Assert.IsTrue(nodes[0][0][0].Command.GetType().IsAssignableTo(typeof(ITransactionStart)));
            Assert.IsTrue(nodes[0][0][0][0].Command.GetType().IsAssignableTo(typeof(IStatementPrepare)));
            Assert.IsTrue(nodes[0][0][0][1].Command.GetType().IsAssignableTo(typeof(IStatementStart)));
            Assert.IsTrue(nodes[0][0][0][1][0].Command.GetType().IsAssignableTo(typeof(IProcedureStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][0].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][1].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][2].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][2][0].Command.GetType().IsAssignableTo(typeof(IProcedureStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][2][0][0].Command.GetType().IsAssignableTo(typeof(IFunctionStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][2][0][0][0].Command.GetType().IsAssignableTo(typeof(IFunctionStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][2][0][0][1].Command.GetType().IsAssignableTo(typeof(IFunctionEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][2][0][1].Command.GetType().IsAssignableTo(typeof(IFunctionEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][2][0][2].Command.GetType().IsAssignableTo(typeof(ISetContext)));
            Assert.IsTrue(nodes[0][0][0][1][0][2][1].Command.GetType().IsAssignableTo(typeof(IProcedureEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][3].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][4].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][5].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][6].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][7].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][8].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][9].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][10].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][11].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][0][1][0][12].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][1][0][13].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][0][1][1].Command.GetType().IsAssignableTo(typeof(IProcedureEnd)));
            Assert.IsTrue(nodes[0][0][0][2].Command.GetType().IsAssignableTo(typeof(IStatementFinish)));
            Assert.IsTrue(nodes[0][0][0][3].Command.GetType().IsAssignableTo(typeof(IStatementFree)));
            Assert.IsTrue(nodes[0][0][0][4].Command.GetType().IsAssignableTo(typeof(ITriggerStart)));
            Assert.IsTrue(nodes[0][0][0][4][0].Command.GetType().IsAssignableTo(typeof(IFunctionStart)));
            Assert.IsTrue(nodes[0][0][0][4][0][0].Command.GetType().IsAssignableTo(typeof(IFunctionStart)));
            Assert.IsTrue(nodes[0][0][0][4][0][1].Command.GetType().IsAssignableTo(typeof(IFunctionEnd)));
            Assert.IsTrue(nodes[0][0][0][4][1].Command.GetType().IsAssignableTo(typeof(IFunctionEnd)));
            Assert.IsTrue(nodes[0][0][0][5].Command.GetType().IsAssignableTo(typeof(ITriggerEnd)));
            Assert.IsTrue(nodes[0][0][1].Command.GetType().IsAssignableTo(typeof(ITransactionEnd)));
            Assert.IsTrue(nodes[0][1].Command.GetType().IsAssignableTo(typeof(IAttachmentEnd)));
        }

        [Test, Explicit]
        public void File()
        {
            var builder = new ProfilerTreeBuilder();
            builder.LoadFile(@"C:\Users\Jiri\Downloads\trace.txt");
        }
    }
}

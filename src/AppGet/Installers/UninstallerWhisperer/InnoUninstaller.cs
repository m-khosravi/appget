﻿using System.Collections.Generic;
using AppGet.Manifest;

namespace AppGet.Installers.UninstallerWhisperer
{
    public class InnoUninstaller : UninstallerBase
    {
        // http://www.jrsoftware.org/ishelp/index.php?topic=setupexitcodes
        public override Dictionary<int, ExistReason> ExitCodes => new Dictionary<int, ExistReason>
        {
            {
                1, new ExistReason(ExitCodeTypes.Failed, "Setup failed to initialize")
            },
            {
                2, new ExistReason(ExitCodeTypes.UserCanceled)
            },
            {
                3,
                new ExistReason(ExitCodeTypes.Failed,
                    "A fatal error occurred while preparing to move to the next installation phase. This should never happen except under the most unusual of circumstances, such as running out of memory or Windows resources.")
            },
            {
                4, new ExistReason(ExitCodeTypes.Failed, "A fatal error occurred during the actual installation process.")
            },
            {
                5, new ExistReason(ExitCodeTypes.UserCanceled)
            },
            {
                7, new ExistReason(ExitCodeTypes.RequirementUnmet, "The Preparing to Install stage determined that Setup cannot proceed with installation.")
            },
            {
                8,
                new ExistReason(ExitCodeTypes.RestartRequired,
                    "The Preparing to Install stage determined that Setup cannot proceed with installation, and that the system needs to be restarted in order to correct the problem.")
            },
            {
                3010, new ExistReason(ExitCodeTypes.RestartRequired, null, true)
            }
        };

        public override InstallMethodTypes InstallMethod => InstallMethodTypes.Inno;
        public override string InteractiveArgs => "";

        //Command line args: http://www.jrsoftware.org/ishelp/index.php?topic=setupcmdline

        private const string BASE_ARG = "/NOCANCEL /SUPPRESSMSGBOXES /NORESTART /CLOSEAPPLICATIONS /FORCECLOSEAPPLICATIONS /NORESTARTAPPLICATIONS /RESTARTEXITCODE=3010";
        public override string PassiveArgs => $"/SILENT {BASE_ARG}";
        public override string SilentArgs => $"/VERYSILENT {BASE_ARG}";
        public override string LogArgs => "/LOG={path}";
    }
}
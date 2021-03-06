---


---

<p><a href="https://dev.azure.com/ItsMajestiX/ServerModManager/_build/latest?definitionId=1&amp;branchName=master"><img src="https://dev.azure.com/ItsMajestiX/ServerModManager/_apis/build/status/ItsMajestiX.ServerModManager?branchName=master" alt="Build Status"></a></p>
<h1 id="servermodmanager">ServerModManager</h1>
<p>A package manager for SCP: Secret Laboratory</p>
<p><em>So apparently the official SMod team is working on something similar to this. When it releases, I’ll archive this and switch over to the official version. Until then, the project isn’t going anywhere.</em></p>
<p>SeverModManager is designed to make installing <a href="https://github.com/Grover-c13/Smod2">SMod2</a> packages easier. It’s modeled after pip, so if you have worked with that, you’re good to go.</p>
<p>Install by simply running <code>scpman install packagename</code>, and remove with <code>scpman remove packagename</code>.  When it’s time to update, just run <code>scpman update packagename</code>. Simple!</p>
<p>Dependencies are automatically taken care of, so you don’t have to install everything one at a time.</p>
<p>Uses .NET Core, so it can be run on Windows and Linux (and maybe even OS X…)</p>
<h1 id="ci-builds">CI Builds</h1>
<p>If you want fresh off the press packages, get them <a href="https://dev.azure.com/ItsMajestiX/ServerModManager/">here</a> under the most recent build as artifacts. Releases do nothing, so don’t go there.</p>
<h1 id="install">Install</h1>
<p>Create a new folder at the same level as sm_plugins and unzip the files there. Now you’re good to go!</p>
<h1 id="packages">Packages</h1>
<p>See <a href="https://github.com/ItsMajestiX/ServerModManager/blob/master/packages.md">here</a> for a list of currently available packages</p>
<h1 id="note-on-json">Note on JSON</h1>
<p>The JSON format will change a lot, so it’s a good idea to get every new release. I’ll freeze the format in v1.0, but untill then, things are subject to change without warning.</p>
<h1 id="about-testing-server">About Testing Server</h1>
<p>The directory TestingServer is a directory you can use to debug the program without needing to download from the repository. Just install Python 3 and run server.bat.</p>
<h1 id="to-do">To Do</h1>
<ul>
<li>Futureproof JSON</li>
<li>Install from file of requirements</li>
<li>Add incompatibilities</li>
<li>Fix bug where download finishes before loading bar displays</li>
<li>Follow ERROR, WARNING, and INFO conventions more strictly</li>
<li>Make updater script</li>
</ul>
<h1 id="for-modders">For Modders</h1>
<p>Get your mod added to the list! DM me on discord at MajestiX#7652.</p>
<h1 id="credits">Credits</h1>
<p><a href="https://github.com/JamesNK/Newtonsoft.Json">Newtonsoft.JSON (JSON processing)</a></p>
<p><a href="https://github.com/silkfire/Pastel">Pastel (colored command line text)</a></p>
<p>Special thanks to <a href="https://github.com/VirtualBrightPlayz">VirtualBrightPlayz</a> for making the packing I tested on in the begining: <a href="https://github.com/VirtualBrightPlayz/Smod2-Mod1_DCLASS_MADNESS">dclassmadneess</a></p>
<blockquote>
<p>Written with <a href="https://stackedit.io/">StackEdit</a>.</p>
</blockquote>

using System;
using System.Runtime.InteropServices;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
    "Sweeper",
    Namespace = "MonoDevelop",
    Version = "0.2", 
    Category = "IDE extensions"
)]

[assembly: AddinName("Sweeper")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("VS4Mac addin with functionality related to cleaning the output.")]
[assembly: AddinAuthor("Javier Suárez Ruiz")]
[assembly: AddinUrl("https://github.com/jsuarezruiz/VS4Mac-Sweeper")]

[assembly: CLSCompliant(false)]
[assembly: ComVisible(false)]
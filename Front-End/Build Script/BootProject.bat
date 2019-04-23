cd C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin
MSBuild.exe "C:\Users\newtn\Documents\GitHub\StephanG12\Front-End\Appgregate\Appgregate.sln"
cd C:\Program Files (x86)\IIS Express
start "" http://localhost:55173
iisexpress /path:C:\Users\newtn\Documents\GitHub\StephanG12\Front-End\Appgregate\Appgregate /port:55173


/*
- exe = dll + main func
- compiler turns C# into native code (machine lang)

.NET = 2002, collection of technologies to develop cross platform applications
{
    - .net framework
    - .net core
    ...
    - .net 7
}

- C# is the language of .NET [including others: VB.Net, visual c++.Net [produce native], F#, J#, ...]
    - statically typed language
    - pure OOP (has some similar features of functional programming)

    - C# compiled on csc.exe -> MS compiler
        - produces CIL [common intermediate language] or IL -> translates to platform specifice native later

            - runs on RUNTIME ENVIRONMENT -> .NET [represent an OS layer]
            - CLR: common language runtime
                - Just-In-Time compiler transforms CIL to native [64-bit]

            - cons:
                - overhead time of JIT
                    - paid once, native code is cached while running
                - dependent on CLR being installed
                    - IL is readable -> security and license
                    - obfuscator -> transforms clean IL to unreadable IL

- .Net core: 2016
    - cross platform
    - open source
    - component based: nuget: package manager, install per project

    - .NET core 5.x -> known as .NET (supports all components of old versions)


- C# datatypes:
    - base class library (framework class library)
    - enum
    - struct

- solution: multiple projects
*/
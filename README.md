# Donut-Roll

A candy themed 3-lane endless runner made in C# with Unity.

To play, clone or download this repo and run [DonutRoll.exe](https://github.com/Jibzi/Donut-Roll/tree/master/DonutGame) in the DonutGame folder.

This repo uses [Git LFS](https://git-lfs.github.com/) to store larger game assets. Install it to avoid [graphical errors](https://help.github.com/en/github/managing-large-files/collaboration-with-git-large-file-storage) and clone this repo via [Git Bash or Git GUI](https://gitforwindows.org/) for optimum results. Check out other features <a href="#Features">below</a>.

#### Video:
<a href="http://www.youtube.com/watch?feature=player_embedded&v=EJwDCta1Q34" target="_blank"><img src="https://static.wixstatic.com/media/3978e6_577023bfc9444415900811be9a1c7585f003.jpg/v1/fill/w_756,h_425,fp_0.50_0.50,q_90/3978e6_577023bfc9444415900811be9a1c7585f003.webp" alt="Video Clip of Donut Roller" width="853" height="480" border="10" /></a>


<h2 id="Features">Key Features:</h2>

* A [shader](https://github.com/Jibzi/Donut-Roll/blob/master/DonutGit/Assets/Scripts/George/WorldBender.cs) that curves the world
* A robust [collectables system](https://github.com/Jibzi/Donut-Roll/blob/master/DonutGit/Assets/Scripts/George/Interact/Interactable.cs)
* A custom [audio management system](https://github.com/Jibzi/Donut-Roll/blob/master/DonutGit/Assets/Scripts/Kieran/AudioManager.cs)
* A powerful [input manager](https://github.com/Jibzi/Donut-Roll/blob/master/DonutGit/Assets/Scripts/Will/InputHandler.cs) that tracks key metadata
* [Pickups](https://github.com/Jibzi/Donut-Roll/blob/master/DonutGit/Assets/Scripts/Kieran/Collectable.cs) that add to your score, or accelerate your donut
* [Hazards](https://github.com/Jibzi/Donut-Roll/blob/master/DonutGit/Assets/Scripts/Kieran/Obstacle.cs) that slow down or stop your donut
* A difficulty system orientated around a [jerk-based acceleration system](https://github.com/Jibzi/Donut-Roll/blob/master/DonutGit/Assets/Scripts/George/WorldMover.cs#L13) that increases your acceleration over time, so even if you slow down 5 minuites in you get back up to speed in no time!

The libmonosgen-2.0-assert-patch.so is a binary patch of the arm64-v8a library shipped with embeddinator 4000.
The patch, manually backports the mono change from this commit
https://github.com/mono/mono/commit/06673e723ec3d59b071a1b763680f252b71c5de4, which fixes crashes when targeting
android 14 https://github.com/dotnet/runtime/issues/73197.

The binary patch changes the instruction
```
001f52e0 4a 04 00 54     b.ge       LAB_001f5368
```
to
```
001f52e0 4c 04 00 54     b.gt       LAB_001f5368
```
which corresponds to the assert changed in the above commit.
In the shared object itself, this instruction is located at offset `f52e0` of the file.

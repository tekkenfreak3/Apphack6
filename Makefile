PLAT = Unix

ifeq ($(PLAT), Unix)
	EXTERN = "extern/unix/"
	FLAGS += -reference:"$(EXTERN)/MonoGame.Framework"
	POST = cp $(EXTERN)/*.dll .
endif

all: jump.exe

jump.exe:
	@gmcs jump.cs $(FLAGS)


PLAT = Unix

ifeq ($(PLAT), Unix)
	EXTERN = extern/unix
	FLAGS += -reference:"$(EXTERN)/MonoGame.Framework" -reference:"$(EXTERN)/Tao.Sdl.dll"
	POST = cp $(EXTERN)/*.dll .
endif

all: run

Jump.exe:
	mcs $(FLAGS) Jump.cs

run: Jump.exe
	$(POST);
	mono ./Jump.exe
	rm *.dll

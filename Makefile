PLAT = Unix
SRC = Jump.cs JumpSprite.cs Player.cs GameElements/Block.cs
ifeq ($(PLAT), Unix)
	EXTERN = extern/unix
	FLAGS += -reference:"$(EXTERN)/MonoGame.Framework" -reference:"$(EXTERN)/Tao.Sdl.dll"
	POST = cp $(EXTERN)/*.dll .
endif

all: run

Jump.exe:
	rm Jump.exe || echo "Jump not here"
	mcs $(FLAGS) $(SRC)

run: Jump.exe
	$(POST);
	mono ./Jump.exe
	rm *.dll

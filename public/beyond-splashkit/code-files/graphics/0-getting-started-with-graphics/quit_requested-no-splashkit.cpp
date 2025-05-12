#include <iostream>
#ifdef __APPLE__
#include <SDL.h>
#else
#include <SDL2/SDL.h>
#endif

SDL_Window *sdl_open_window(const char *window_title, const int width, const int height)
{
    // This function demonstrates how we can open window without SplashKit.

    // Declare Variables
    SDL_Window *window = nullptr;

    // Check for successful initialisation
    if (SDL_Init(SDL_INIT_VIDEO) < 0)
    {
        std::cout << "SDL could not be initialized: " << SDL_GetError();
        exit(1);
    }

    // Create Window
    window = SDL_CreateWindow(
        window_title,
        SDL_WINDOWPOS_CENTERED,
        SDL_WINDOWPOS_CENTERED,
        width,
        height,
        SDL_WINDOW_OPENGL);

    // Error handling for window
    if (window == NULL)
    {
        SDL_LogError(SDL_LOG_CATEGORY_ERROR, "Could not create window: %s\n", SDL_GetError());
        exit(1);
    }

    return window;
}

int main(int argv, char **args)
{
    SDL_Window *window = sdl_open_window("No SK Window: QuitRequested", 800, 600);

    // Hang window until quit
    SDL_Event event;
    while (event.type != SDL_QUIT)
    {
        SDL_PollEvent(&event);
    }

    // Cleanup and free memory
    SDL_DestroyWindow(window);

    return 0;
}
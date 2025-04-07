
#include <iostream>
#ifdef __APPLE__
#include <SDL.h>
#else
#include <SDL2/SDL.h>
#endif

int main(int argv, char **args)
{
    // Opening a Window without SplashKit

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
        "No SK Window: OpenWindow",
        SDL_WINDOWPOS_CENTERED,
        SDL_WINDOWPOS_CENTERED,
        800,
        600,
        SDL_WINDOW_OPENGL);

    // Error handling for window
    if (window == NULL)
    {
        SDL_LogError(SDL_LOG_CATEGORY_ERROR, "Could not create window: %s\n", SDL_GetError());
        exit(1);
    }

    // Hold window open for 4 seconds
    Uint32 start_time = SDL_GetTicks(); // Start timer
    SDL_Event event;

    while (SDL_GetTicks() - start_time < 4000) // Run for 4 seconds
    {
        if (SDL_PollEvent(&event) && event.type == SDL_QUIT) break;
    }

    // Cleanup and free memory
    SDL_DestroyWindow(window);

    return 0;
}
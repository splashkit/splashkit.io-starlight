#include <iostream>
#ifdef __APPLE__
#include <SDL.h>
#else
#include <SDL2/SDL.h>
#endif

SDL_Window *sdl_open_window(const char *window_title, const int width, const int height)
{
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
    // Open window with title and dimensions
    SDL_Window *window = sdl_open_window("Blue Background", 800, 600);

    // Create renderer
    SDL_Renderer *renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);
    if (renderer == NULL)
    {
        SDL_LogError(SDL_LOG_CATEGORY_ERROR, "Could not create renderer: %s\n", SDL_GetError());
        exit(1);
    }
    
    // Clear screen to blue
    SDL_SetRenderDrawColor(renderer, 0, 0, 255, 255);
    SDL_RenderClear(renderer);
    SDL_RenderPresent(renderer);

    Uint32 start_time = SDL_GetTicks(); // Start timer
    SDL_Event event;

    while (SDL_GetTicks() - start_time < 4000) // Run for 4 seconds
    {
        if (SDL_PollEvent(&event) && event.type == SDL_QUIT) break;
    }

    // Cleanup and free memory
    SDL_DestroyRenderer(renderer);
    SDL_DestroyWindow(window);
    SDL_Quit();

    return 0;
}
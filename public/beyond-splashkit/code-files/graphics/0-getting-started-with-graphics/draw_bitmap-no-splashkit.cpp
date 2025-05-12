#include <iostream>
#ifdef __APPLE__
#include <SDL.h>
#include <SDL_image.h>
#else
#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>
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

SDL_Renderer *sdl_create_renderer(SDL_Window *window)
{
    SDL_Renderer *renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);
    if (renderer == NULL)
    {
        SDL_LogError(SDL_LOG_CATEGORY_ERROR, "Could not create rederer: %s\n", SDL_GetError());
        exit(1);
    }
    return renderer;
}

int main(int argv, char **args)
{
    SDL_Window *window = sdl_open_window("No SK Window: DrawBitmap", 800, 600);
    SDL_Renderer *renderer = sdl_create_renderer(window);

    // Load image
    // Create a surface for imported image
    SDL_Surface *image = IMG_Load("Resources/images/photo.jpg");
    if (image == NULL)
    {
        std::cout << "Failed to load photo.jpg" << SDL_GetError();
        exit(1);
    }

    // Convert surface to texture
    SDL_Texture *image_texture = SDL_CreateTextureFromSurface(renderer, image);
    if (image_texture == NULL)
    {
        std::cout << "Failed to create texture" << SDL_GetError();
        exit(1);
    }

    // Free memory
    SDL_FreeSurface(image);

    // Get image size to avoid stretching
    int background_width = 0, background_height = 0;
    SDL_QueryTexture(image_texture, NULL, NULL, &background_width, &background_height);

    // Hang window until quit
    SDL_Event event;
    while (event.type != SDL_QUIT)
    {
        SDL_PollEvent(&event);

        // Clear screen with black
        SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
        SDL_RenderClear(renderer);

        // Draw image to screen
        SDL_Rect image_rect = { 75, 125, background_width, background_height }; 
        SDL_RenderCopy(renderer, image_texture, NULL, &image_rect);

        // Display drawing
        SDL_RenderPresent(renderer);
    }

    // Cleanup and free memory
    SDL_DestroyWindow(window);
    SDL_DestroyRenderer(renderer);

    return 0;
}
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
    if (!(IMG_Init(IMG_INIT_PNG | IMG_INIT_JPG) & (IMG_INIT_PNG | IMG_INIT_JPG)))
    {
        std::cout << "Failed to initialize SDL_image: " << IMG_GetError();
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
    // Print instructions in terminal
    std::cout << "\nClick anywhere on the image to change the background colour\n\n";

    // Declare Variables
    int mouse_x, mouse_y;
    unsigned int clr = 0;
    SDL_Color mouse_color = {0, 0, 0, 255};

    // Open Window
    SDL_Window *window = sdl_open_window("No SK Window: SDL2 Eyedropper", 800, 600);

    // Create renderer
    SDL_Renderer *renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);
    if (renderer == NULL)
    {
        SDL_LogError(SDL_LOG_CATEGORY_ERROR, "Could not create rederer: %s\n", SDL_GetError());
        exit(1);
    }

    // Create textures for eye drop and background image
    SDL_Surface *background = IMG_Load("Resources/images/photo.jpg");
    if (background == NULL)
    {
        std::cout << "Failed to load background.jpg" << SDL_GetError();
        exit(1);
    }

    SDL_Texture *background_texture = SDL_CreateTextureFromSurface(renderer, background);
    if (background_texture == NULL)
    {
        std::cout << "Failed to create texture" << SDL_GetError();
        exit(1);
    }
    SDL_FreeSurface(background);
    SDL_Surface *eyedrop = IMG_Load("Resources/images/eyedrop.png");
    if (eyedrop == NULL)
    {
        std::cout << "Failed to load eyedrop.png" << SDL_GetError();
        exit(1);
    }

    SDL_Texture *eyedrop_texture = SDL_CreateTextureFromSurface(renderer, eyedrop);
    if (eyedrop_texture == NULL)
    {
        std::cout << "Failed to create texture" << SDL_GetError();
        exit(1);
    }
    SDL_FreeSurface(eyedrop);

    // Get the native dimensions of the textures
    int background_width = 0, background_height = 0, eyedrop_width = 0, eyedrop_height = 0;
    SDL_QueryTexture(background_texture, NULL, NULL, &background_width, &background_height);
    SDL_QueryTexture(eyedrop_texture, NULL, NULL, &eyedrop_width, &eyedrop_height);

    SDL_Event event;
    while (event.type != SDL_QUIT)
    {
        // Check for quit requested
        SDL_PollEvent(&event);

        // Clear screen with mouse color
        SDL_SetRenderDrawColor(renderer, mouse_color.r, mouse_color.g, mouse_color.b, mouse_color.a);
        SDL_RenderClear(renderer);

        // Draw background
        SDL_Rect background_rect = {75, 125, background_width, background_height};
        SDL_RenderCopy(renderer, background_texture, NULL, &background_rect);

        // Get the mouse position
        SDL_GetMouseState(&mouse_x, &mouse_y);
        SDL_Rect rect = {mouse_x, mouse_y, 1, 1};

        // Draw eyedropper as curser
        SDL_Rect eyedrop_rect = {mouse_x - 3, mouse_y - eyedrop_height + 3, eyedrop_width, eyedrop_height};
        SDL_RenderCopy(renderer, eyedrop_texture, NULL, &eyedrop_rect);
        SDL_ShowCursor(SDL_DISABLE);

        // Set color at cursor when click
        if (event.type == SDL_MOUSEBUTTONDOWN)
        {
            SDL_RenderReadPixels(renderer, &rect, SDL_PIXELFORMAT_RGBA8888, &clr, 1);
            SDL_GetRGBA(clr, SDL_AllocFormat(SDL_PIXELFORMAT_RGBA8888), &mouse_color.r, &mouse_color.g, &mouse_color.b, &mouse_color.a);
        }

        // Display drawing
        SDL_RenderPresent(renderer);
    }
    // Cleanup and free memory
    SDL_DestroyTexture(background_texture);
    SDL_DestroyTexture(eyedrop_texture);
    SDL_DestroyRenderer(renderer);
    SDL_DestroyWindow(window);
    SDL_Quit();

    return 0;
}
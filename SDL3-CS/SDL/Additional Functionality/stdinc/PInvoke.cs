#region License
/* Copyright (c) 2024-2026 Eduard Gushchin.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 */
#endregion

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL3;

public partial class SDL
{
    /// <code>extern SDL_DECLSPEC SDL_MALLOC void * SDLCALL SDL_malloc(size_t size);</code>
    /// <summary>
    /// <para>Allocate uninitialized memory.</para>
    /// <para>The allocated memory returned by this function must be freed with
    /// <see cref="Free"/>.</para>
    /// <para>If <c>size</c> is 0, it will be set to 1.</para>
    /// <para>If you want to allocate memory aligned to a specific alignment, consider
    /// using <see cref="AlignedAlloc"/>.</para>
    /// <para>If the allocation is successful, the returned pointer is guaranteed to be
    /// aligned to either the *fundamental alignment* (`alignof(max_align_t)` in
    /// C11 and later) or `2 * sizeof(void *)`, whichever is smaller. Use
    /// SDL_aligned_alloc() if you need to allocate memory aligned to an alignment
    /// greater than this guarantee.</para>
    /// </summary>
    /// <param name="size">the size to allocate.</param>
    /// <returns>a pointer to the allocated memory, or <c>null</c> if allocation failed.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="Free"/>
    /// <seealso cref="Calloc"/>
    /// <seealso cref="Realloc"/>
    /// <seealso cref="AlignedAlloc"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_malloc"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Malloc(UIntPtr size);
    
    
    /// <code>extern SDL_DECLSPEC SDL_MALLOC SDL_ALLOC_SIZE2(1, 2) void * SDLCALL SDL_calloc(size_t nmemb, size_t size);</code>
    /// <summary>
    /// <para>Allocate a zero-initialized array.</para>
    /// <para>The memory returned by this function must be freed with <see cref="Free"/>.</para>
    /// <para>If either of <c>nmemb</c> or <c>size</c> is 0, they will both be set to 1.</para>
    /// <para>If the allocation is successful, the returned pointer is guaranteed to be
    /// aligned to either the *fundamental alignment* (`alignof(max_align_t)` in
    /// C11 and later) or `2 * sizeof(void *)`, whichever is smaller.</para>
    /// </summary>
    /// <param name="nmemb">the number of elements in the array.</param>
    /// <param name="size">the size of each element of the array.</param>
    /// <returns>a pointer to the allocated array, or <c>null</c> if allocation failed.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_calloc"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Calloc(UIntPtr nmemb, UIntPtr size);
    
    
    /// <code>extern SDL_DECLSPEC SDL_ALLOC_SIZE(2) void * SDLCALL SDL_realloc(void *mem, size_t size);</code>
    /// <summary>
    /// <para>Change the size of allocated memory.</para>
    /// <para>The memory returned by this function must be freed with <see cref="Free"/>.</para>
    /// <para>If <c>size</c> is 0, it will be set to 1. Note that this is unlike some other C
    /// runtime <c>realloc</c> implementations, which may treat <c>realloc(mem, 0)</c> the
    /// same way as <c>free(mem)</c>.</para>
    /// <para>If <c>mem</c> is <c>null</c>, the behavior of this function is equivalent to
    /// <see cref="Malloc"/>. Otherwise, the function can have one of three possible
    /// outcomes:</para>
    /// <list type="bullet">
    /// <item>If it returns the same pointer as <c>mem</c>, it means that <c>mem</c> was resized
    /// in place without freeing.</item>
    /// <item>If it returns a different non-NULL pointer, it means that <c>mem</c> was freed
    /// and cannot be dereferenced anymore.</item>
    /// <item>If it returns <c>null</c> (indicating failure), then <c>mem</c> will remain valid and
    /// must still be freed with <see cref="Free"/>.</item>
    /// </list>
    /// <para>If the allocation is successfully resized, the returned pointer is
    /// guaranteed to be aligned to either the *fundamental alignment*
    /// (`alignof(max_align_t)` in C11 and later) or `2 * sizeof(void *)`,
    /// whichever is smaller.</para>
    /// </summary>
    /// <param name="mem">a pointer to allocated memory to reallocate, or <c>null</c>.</param>
    /// <param name="size">the new size of the memory.</param>
    /// <returns>a pointer to the newly allocated memory, or <c>null</c> if allocation
    /// failed.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="Free"/>
    /// <seealso cref="Malloc"/>
    /// <seealso cref="Calloc"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_realloc"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Realloc(IntPtr mem, UIntPtr size);
    
    
    /// <code>extern SDL_DECLSPEC void SDLCALL SDL_free(void *mem);</code>
    /// <summary>
    /// <para>Free allocated memory.</para>
    /// <para>The pointer is no longer valid after this call and cannot be dereferenced
    /// anymore.</para>
    /// <para>If <c>mem</c> is <c>null</c>, this function does nothing.</para>
    /// </summary>
    /// <param name="mem">a pointer to allocated memory, or <c>null</c>.</param>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_free"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Free(IntPtr mem);
    
    
    /// <code>extern SDL_DECLSPEC void SDLCALL SDL_GetOriginalMemoryFunctions(SDL_malloc_func *malloc_func, SDL_calloc_func *calloc_func, SDL_realloc_func *realloc_func, SDL_free_func *free_func);</code>
    /// <summary>
    /// <para>Get the original set of SDL memory functions.</para>
    /// <para>This is what <see cref="Malloc"/> and friends will use by default, if there has been
    /// no call to <see cref="SetMemoryFunctions"/>. This is not necessarily using the C
    /// runtime's <c>malloc</c> functions behind the scenes! Different platforms and
    /// build configurations might do any number of unexpected things.</para>
    /// </summary>
    /// <param name="mallocFunc">filled with malloc function.</param>
    /// <param name="callocFunc">filled with calloc function.</param>
    /// <param name="reallocFunc">filled with realloc function.</param>
    /// <param name="freeFunc">filled with free function.</param>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_GetOriginalMemoryFunctions"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetOriginalMemoryFunctions(out MallocFunc mallocFunc, out CallocFunc callocFunc, out ReallocFunc reallocFunc, out FreeFunc freeFunc);
    
    
    /// <code>extern SDL_DECLSPEC void SDLCALL SDL_GetMemoryFunctions(SDL_malloc_func *malloc_func, SDL_calloc_func *calloc_func, SDL_realloc_func *realloc_func, SDL_free_func *free_func);</code>
    /// <summary>
    /// <para>Get the current set of SDL memory functions.</para>
    /// </summary>
    /// <param name="mallocFunc">filled with malloc function.</param>
    /// <param name="callocFunc">filled with calloc function.</param>
    /// <param name="reallocFunc">filled with realloc function.</param>
    /// <param name="freeFunc">filled with free function.</param>
    /// <threadsafety>This does not hold a lock, so do not call this in the
    /// unlikely event of a background thread calling
    /// <see cref="SetMemoryFunctions"/> simultaneously.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="SetMemoryFunctions"/>
    /// <seealso cref="GetOriginalMemoryFunctions"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_GetMemoryFunctions"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetMemoryFunctions(out MallocFunc mallocFunc, out CallocFunc callocFunc, out ReallocFunc reallocFunc, out FreeFunc freeFunc);
    
    
    /// <code>extern SDL_DECLSPEC bool SDLCALL SDL_SetMemoryFunctions(SDL_malloc_func malloc_func, SDL_calloc_func calloc_func, SDL_realloc_func realloc_func, SDL_free_func free_func);</code>
    /// <summary>
    /// <para>Replace SDL's memory allocation functions with a custom set.</para>
    /// <para>It is not safe to call this function once any allocations have been made,
    /// as future calls to SDL_free will use the new allocator, even if they came
    /// from an SDL_malloc made with the old one!</para>
    /// <para>If used, usually this needs to be the first call made into the SDL library,
    /// if not the very first thing done at program startup time.</para>
    /// </summary>
    /// <param name="mallocFunc">custom malloc function.</param>
    /// <param name="callocFunc">custom calloc function.</param>
    /// <param name="reallocFunc">custom realloc function.</param>
    /// <param name="freeFunc">custom free function.</param>
    /// <returns><c>true</c> on success or <c>false</c> on failure; call <see cref="GetError"/> for more
    /// information.</returns>
    /// <threadsafety>It is safe to call this function from any thread, but one
    /// should not replace the memory functions once any allocations
    /// are made!</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="GetMemoryFunctions"/>
    /// <seealso cref="GetOriginalMemoryFunctions"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_SetMemoryFunctions"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool SetMemoryFunctions(MallocFunc mallocFunc, CallocFunc callocFunc, ReallocFunc reallocFunc, FreeFunc freeFunc);
    
    
    /// <code>extern SDL_DECLSPEC SDL_MALLOC void * SDLCALL SDL_aligned_alloc(size_t alignment, size_t size);</code>
    /// <summary>
    /// <para>Allocate memory aligned to a specific alignment.</para>
    /// <para>The memory returned by this function must be freed with <see cref="AlignedFree"/>,
    /// _not_ <see cref="Free"/>.</para>
    /// <para>If <c>alignment</c> is less than the size of <c>void *</c>, it will be increased to
    /// match that.</para>
    /// <para>The returned memory address will be a multiple of the alignment value, and
    /// the size of the memory allocated will be a multiple of the alignment value.</para>
    /// </summary>
    /// <param name="alignment">the alignment of the memory.</param>
    /// <param name="size">the size to allocate.</param>
    /// <returns>a pointer to the aligned memory, or <c>null</c> if allocation failed.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="AlignedFree"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_aligned_alloc"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr AlignedAlloc(UIntPtr alignment, UIntPtr size);
    
    
    /// <code>extern SDL_DECLSPEC void SDLCALL SDL_aligned_free(void *mem);</code>
    /// <summary>
    /// <para>Free memory allocated by <see cref="AlignedAlloc"/>.</para>
    /// <para>The pointer is no longer valid after this call and cannot be dereferenced
    /// anymore.</para>
    /// <para>If <c>mem</c> is <c>null</c>, this function does nothing.</para>
    /// </summary>
    /// <param name="mem">a pointer previously returned by <see cref="AlignedAlloc"/>, or <c>null</c>.</param>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="AlignedFree"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_aligned_alloc"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void AlignedFree(IntPtr mem);
    
    
    /// <code>extern SDL_DECLSPEC int SDLCALL SDL_GetNumAllocations(void);</code>
    /// <summary>
    /// Get the number of outstanding (unfreed) allocations.
    /// </summary>
    /// <returns>the number of allocations or -1 if allocation counting is
    /// disabled.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_GetNumAllocations"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumAllocations();
    
    
    /// <code>extern SDL_DECLSPEC SDL_Environment * SDLCALL SDL_GetEnvironment(void);</code>
    /// <summary>
    /// <para>Get the process environment.</para>
    /// <para>This is initialized at application start and is not affected by setenv()
    /// and unsetenv() calls after that point. Use <see cref="SetEnvironmentVariable"/> and
    /// <see cref="UnsetEnvironmentVariable"/> if you want to modify this environment, or
    /// SDL_setenv_unsafe() or SDL_unsetenv_unsafe() if you want changes to persist
    /// in the C runtime environment after <see cref="Quit"/>.</para>
    /// </summary>
    /// <returns>a pointer to the environment for the process or <c>null</c> on failure;
    /// call <see cref="GetError"/> for more information.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="GetEnvironmentVariable"/>
    /// <seealso cref="GetEnvironmentVariables"/>
    /// <seealso cref="SetEnvironmentVariable"/>
    /// <seealso cref="UnsetEnvironmentVariable"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_GetEnvironment"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr GetEnvironment();
    
    
    /// <code>extern SDL_DECLSPEC SDL_Environment * SDLCALL SDL_CreateEnvironment(bool populated);</code>
    /// <summary>
    /// Create a set of environment variables
    /// </summary>
    /// <param name="populated">true to initialize it from the C runtime environment,
    /// false to create an empty environment.</param>
    /// <returns>a pointer to the new environment or <c>null</c> on failure; call
    /// <see cref="GetError"/> for more information.</returns>
    /// <threadsafety>If <c>populated</c> is false, it is safe to call this function
    /// from any thread, otherwise it is safe if no other threads are
    /// calling setenv() or unsetenv()</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="GetEnvironmentVariable"/>
    /// <seealso cref="GetEnvironmentVariables"/>
    /// <seealso cref="SetEnvironmentVariable"/>
    /// <seealso cref="UnsetEnvironmentVariable"/>
    /// <seealso cref="DestroyEnvironment"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_CreateEnvironment"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr CreateEnvironment([MarshalAs(UnmanagedType.I1)] bool populated);
    
    
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_GetEnvironmentVariable"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_GetEnvironmentVariable(IntPtr env, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
    /// <code>extern SDL_DECLSPEC const char * SDLCALL SDL_GetEnvironmentVariable(SDL_Environment *env, const char *name);</code>
    /// <summary>
    /// <para>Get the value of a variable in the environment.</para>
    /// </summary>
    /// <param name="env">the environment to query.</param>
    /// <param name="name">the name of the variable to get.</param>
    /// <returns>a pointer to the value of the variable or <c>null</c> if it can't be
    /// found.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="GetEnvironment"/>
    /// <seealso cref="CreateEnvironment"/>
    /// <seealso cref="GetEnvironmentVariables"/>
    /// <seealso cref="SetEnvironmentVariable"/>
    /// <seealso cref="UnsetEnvironmentVariable"/>
    public static string? GetEnvironmentVariable(IntPtr env, string name)
    {
        var value = SDL_GetEnvironmentVariable(env, name); 
        return value == IntPtr.Zero ? null : Marshal.PtrToStringUTF8(value);
    }
    
    
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_GetEnvironmentVariables"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_GetEnvironmentVariables(IntPtr env); 
    /// <code>extern SDL_DECLSPEC char ** SDLCALL SDL_GetEnvironmentVariables(SDL_Environment *env);</code>
    /// <summary>
    /// Get all variables in the environment.
    /// </summary>
    /// <param name="env">the environment to query.</param>
    /// <returns>a <c>null</c> terminated array of pointers to environment variables in
    /// the form "variable=value" or <c>null</c> on failure; call <see cref="GetError"/>
    /// for more information. This is a single allocation that should be
    /// freed with <see cref="Free"/> when it is no longer needed.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="GetEnvironment"/>
    /// <seealso cref="CreateEnvironment"/>
    /// <seealso cref="GetEnvironmentVariables"/>
    /// <seealso cref="SetEnvironmentVariable"/>
    /// <seealso cref="UnsetEnvironmentVariable"/>
    public static string[]? GetEnvironmentVariables(IntPtr env)
    {
        var ptr = SDL_GetEnvironmentVariables(env);

        try
        {
            return PointerToStringArray(ptr);
        }
        finally
        {
            Free(ptr);
        }
    }
    
    
    /// <code>extern SDL_DECLSPEC bool SDLCALL SDL_SetEnvironmentVariable(SDL_Environment *env, const char *name, const char *value, bool overwrite);</code>
    /// <summary>
    /// Set the value of a variable in the environment.
    /// </summary>
    /// <param name="env">the environment to modify.</param>
    /// <param name="name">the name of the variable to set.</param>
    /// <param name="value">the value of the variable to set.</param>
    /// <param name="overwrite"><c>true</c> to overwrite the variable if it exists, <c>false</c> to
    /// return success without setting the variable if it already
    /// exists.</param>
    /// <returns><c>true</c> on success or <c>false</c> on failure; call <see cref="GetError"/> for more
    /// information.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="GetEnvironment"/>
    /// <seealso cref="CreateEnvironment"/>
    /// <seealso cref="GetEnvironmentVariable"/>
    /// <seealso cref="GetEnvironmentVariables"/>
    /// <seealso cref="UnsetEnvironmentVariable"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_SetEnvironmentVariable"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool SetEnvironmentVariable(IntPtr env, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, 
        [MarshalAs(UnmanagedType.LPUTF8Str)] string value, [MarshalAs(UnmanagedType.I1)] bool overwrite);
    
    
    /// <code>extern SDL_DECLSPEC bool SDLCALL SDL_UnsetEnvironmentVariable(SDL_Environment *env, const char *name);</code>
    /// <summary>
    /// Clear a variable from the environment.
    /// </summary>
    /// <param name="env">the environment to modify.</param>
    /// <param name="name">the name of the variable to unset.</param>
    /// <returns><c>true</c> on success or <c>false</c> on failure; call <see cref="GetError"/> for more
    /// information.</returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="GetEnvironment"/>
    /// <seealso cref="CreateEnvironment"/>
    /// <seealso cref="GetEnvironmentVariable"/>
    /// <seealso cref="GetEnvironmentVariables"/>
    /// <seealso cref="SetEnvironmentVariable"/>
    /// <seealso cref="UnsetEnvironmentVariable"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_UnsetEnvironmentVariable"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool UnsetEnvironmentVariable(IntPtr env, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
    
    
    /// <code>extern SDL_DECLSPEC void SDLCALL SDL_DestroyEnvironment(SDL_Environment *env);</code>
    /// <summary>
    /// Destroy a set of environment variables.
    /// </summary>
    /// <param name="env">the environment to destroy.</param>
    /// <threadsafety>It is safe to call this function from any thread, as long as
    /// the environment is no longer in use.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="CreateEnvironment"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_DestroyEnvironment"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void DestroyEnvironment(IntPtr env);
    
    
    /// <code>extern SDL_DECLSPEC void SDLCALL SDL_srand(Uint64 seed);</code>
    /// <summary>
    /// Seeds the pseudo-random number generator.
    /// <para>Reusing the seed number will cause Rand() to repeat the same stream of
    /// <c>random</c> numbers.</para>
    /// </summary>
    /// <param name="seed">the value to use as a random number seed, or 0 to use
    /// <see cref="GetPerformanceCounter"/>.</param>
    /// <threadsafety>This should be called on the same thread that calls
    /// Rand*()</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="Rand"/>
    /// <seealso cref="RandBits"/>
    /// <seealso cref="RandF"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_srand"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SRand(ulong seed);
    
    
    /// <code>extern SDL_DECLSPEC Sint32 SDLCALL SDL_rand(Sint32 n);</code>
    /// <summary>
    /// <para>Generate a pseudo-random number less than n for positive n</para>
    /// <para>The method used is faster and of better quality than <c>rand() % n</c>. Odds are
    /// roughly 99.9% even for n = 1 million. Evenness is better for smaller n, and
    /// much worse as n gets bigger.</para>
    /// <para>Example: to simulate a d6 use <c>Rand(6) + 1</c> The +1 converts 0..5 to
    /// 1..6</para>
    /// <para>If you want to generate a pseudo-random number in the full range of Sint32,
    /// you should use: (int)RandBits()</para>
    /// <para>If you want reproducible output, be sure to initialize with SDL_srand()
    /// first.</para>
    /// <para>There are no guarantees as to the quality of the random sequence produced,
    /// and this should not be used for security (cryptography, passwords) or where
    /// money is on the line (loot-boxes, casinos). There are many random number
    /// libraries available with different characteristics and you should pick one
    /// of those to meet any serious needs.</para>
    /// </summary>
    /// <param name="n">the number of possible outcomes. n must be positive.</param>
    /// <returns>a random value in the range of [0 .. n-1].</returns>
    /// <threadsafety>All calls should be made from a single thread</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <see cref="SRand"/>
    /// <seealso cref="RandF"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_rand"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Rand(int n);
    
    
    /// <code>extern SDL_DECLSPEC float SDLCALL SDL_randf(void);</code>
    /// <summary>
    /// <para>Generate a uniform pseudo-random floating point number less than 1.0</para>
    /// <para>If you want reproducible output, be sure to initialize with <see cref="SRand"/>
    /// first.</para>
    /// <para>There are no guarantees as to the quality of the random sequence produced,
    /// and this should not be used for security (cryptography, passwords) or where
    /// money is on the line (loot-boxes, casinos). There are many random number
    /// libraries available with different characteristics and you should pick one
    /// of those to meet any serious needs.</para>
    /// </summary>
    /// <returns>a random value in the range of [0.0, 1.0).</returns>
    /// <threadsafety>All calls should be made from a single thread</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="SRand"/>
    /// <seealso cref="Rand"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_randf"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float RandF();
    
    
    /// <code>extern SDL_DECLSPEC Uint32 SDLCALL SDL_rand_bits(void);</code>
    /// <summary>
    /// <para>Generate 32 pseudo-random bits.</para>
    /// <para>You likely want to use <see cref="Rand"/> to get a psuedo-random number instead.</para>
    /// <para>There are no guarantees as to the quality of the random sequence produced,
    /// and this should not be used for security (cryptography, passwords) or where
    /// money is on the line (loot-boxes, casinos). There are many random number
    /// libraries available with different characteristics and you should pick one
    /// of those to meet any serious needs.</para>
    /// </summary>
    /// <returns>a random value in the range of [0-SDL_MAX_UINT32].</returns>
    /// <threadsafety>All calls should be made from a single thread</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="Rand"/>
    /// <seealso cref="RandF"/>
    /// <seealso cref="SRand"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_rand_bits"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint RandBits();
    
    
    /// <code>extern SDL_DECLSPEC Sint32 SDLCALL SDL_rand_r(Uint64 *state, Sint32 n);</code>
    /// <summary>
    /// <para>Generate a pseudo-random number less than n for positive n</para>
    /// <para>The method used is faster and of better quality than <c>rand() % n</c>. Odds are
    /// roughly 99.9% even for n = 1 million. Evenness is better for smaller n, and
    /// much worse as n gets bigger.</para>
    /// <para>Example: to simulate a d6 use <c>RandR(state, 6) + 1</c> The +1 converts
    /// 0..5 to 1..6</para>
    /// <para>If you want to generate a pseudo-random number in the full range of Sint32,
    /// you should use: (int)RandBitsR(state)</para>
    /// <para>There are no guarantees as to the quality of the random sequence produced,
    /// and this should not be used for security (cryptography, passwords) or where
    /// money is on the line (loot-boxes, casinos). There are many random number
    /// libraries available with different characteristics and you should pick one
    /// of those to meet any serious needs.</para>
    /// </summary>
    /// <param name="state">a pointer to the current random number state, this may not be
    /// <c>null</c>.</param>
    /// <param name="n">the number of possible outcomes. n must be positive.</param>
    /// <returns>a random value in the range of [0 .. n-1].</returns>
    /// <threadsafety>This function is thread-safe, as long as the state pointer
    /// isn't shared between threads.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="Rand"/>
    /// <seealso cref="RandBitsR"/>
    /// <seealso cref="RandFR"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_rand_r"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RandR(ref ulong state, int n);
    
    
    /// <code>extern SDL_DECLSPEC float SDLCALL SDL_randf_r(Uint64 *state);</code>
    /// <summary>
    /// <para>Generate a uniform pseudo-random floating point number less than 1.0</para>
    /// <para>If you want reproducible output, be sure to initialize with <see cref="SRand"/>
    /// first.</para>
    /// <para>There are no guarantees as to the quality of the random sequence produced,
    /// and this should not be used for security (cryptography, passwords) or where
    /// money is on the line (loot-boxes, casinos). There are many random number
    /// libraries available with different characteristics and you should pick one
    /// of those to meet any serious needs.</para>
    /// </summary>
    /// <param name="state">a pointer to the current random number state, this may not be
    /// <c>null</c>.</param>
    /// <returns>a random value in the range of [0.0, 1.0).</returns>
    /// <threadsafety>This function is thread-safe, as long as the state pointer
    /// isn't shared between threads.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="RandBitsR"/>
    /// <seealso cref="RandR"/>
    /// <seealso cref="RandF"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_randf_r"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float RandFR(ref ulong state);
    
    
    /// <code>extern SDL_DECLSPEC Uint32 SDLCALL SDL_rand_bits_r(Uint64 *state);</code>
    /// <summary>
    /// <para>Generate 32 pseudo-random bits.</para>
    /// <para>You likely want to use <see cref="RandR"/> to get a psuedo-random number instead.</para>
    /// <para>There are no guarantees as to the quality of the random sequence produced,
    /// and this should not be used for security (cryptography, passwords) or where
    /// money is on the line (loot-boxes, casinos). There are many random number
    /// libraries available with different characteristics and you should pick one
    /// of those to meet any serious needs.</para>
    /// </summary>
    /// <param name="state">a pointer to the current random number state, this may not be
    /// <c>null</c>.</param>
    /// <returns>a random value in the range of [0-SDL_MAX_UINT32].</returns>
    /// <threadsafety>This function is thread-safe, as long as the state pointer
    /// isn't shared between threads.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    /// <seealso cref="RandR"/>
    /// <seealso cref="RandFR"/>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_rand_bits_r"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint RandBitsR(ref ulong state);


    /// <code>extern SDL_DECLSPEC void * SDLCALL SDL_memset(SDL_OUT_BYTECAP(len) void *dst, int c, size_t len);</code>
    /// <summary>
    /// <para>Initialize all bytes of buffer of memory to a specific value.</para>
    /// <para>This function will set <c>len</c> bytes, pointed to by <c>dst</c>, to the value
    /// specified in <c>c</c>.</para>
    /// <para>Despite <c>c</c> being an <c>int</c> instead of a <c>char</c>, this only operates on
    /// bytes; <c>c</c> must be a value between 0 and 255, inclusive.</para>
    /// </summary>
    /// <param name="dst">the destination memory region. Must not be <c>null</c>.</param>
    /// <param name="c">the byte value to set.</param>
    /// <param name="len">the length, in bytes, to set in <c>dst</c>.</param>
    /// <returns><c>dst</c></returns>
    /// <threadsafety>It is safe to call this function from any thread.</threadsafety>
    /// <since>This function is available since SDL 3.2.0</since>
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_memset"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Memset(IntPtr dst, int c, UIntPtr len);
    
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_getenv"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_getenv([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    public static string? GetEnv(string name)
    {
        var ptr = SDL_getenv(name);
        return ptr == IntPtr.Zero ? null : Marshal.PtrToStringUTF8(ptr);
    }

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_getenv_unsafe"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr SDL_getenv_unsafe([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    public static string? GetEnvUnsafe(string name)
    {
        var ptr = SDL_getenv_unsafe(name);
        return ptr == IntPtr.Zero ? null : Marshal.PtrToStringUTF8(ptr);
    }

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_setenv_unsafe"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetEnvUnsafe(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string value,
        int overwrite
    );

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_unsetenv_unsafe"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int UnsetEnvUnsafe([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_qsort"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void QSort(IntPtr @base, UIntPtr nmemb, UIntPtr size, CompareCallback compare);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_bsearch"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr BSearch(IntPtr key, IntPtr @base, UIntPtr nmemb, UIntPtr size, CompareCallback compare);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_qsort_r"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void QSortR(IntPtr @base, UIntPtr nmemb, UIntPtr size, CompareCallbackR compare, IntPtr userdata);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_bsearch_r"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr BSearchR(IntPtr key, IntPtr @base, UIntPtr nmemb, UIntPtr size, CompareCallbackR compare, IntPtr userdata);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_abs"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Abs(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isalpha"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsAlpha(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isalnum"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsAlnum(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isblank"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsBlank(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_iscntrl"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsCntrl(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isdigit"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsDigit(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isxdigit"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsXDigit(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_ispunct"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsPunct(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isspace"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsSpace(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isupper"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsUpper(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_islower"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsLower(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isprint"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsPrint(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_isgraph"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsGraph(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_toupper"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int ToUpper(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_tolower"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int ToLower(int x);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_crc16"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort Crc16(ushort crc, IntPtr data, UIntPtr len);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_crc32"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint Crc32(uint crc, IntPtr data, UIntPtr len);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_murmur3_32"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint Murmur3_32(IntPtr data, UIntPtr len, uint seed);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_memcpy"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Memcpy(IntPtr dst, IntPtr src, UIntPtr len);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_memmove"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Memmove(IntPtr dst, IntPtr src, UIntPtr len);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_memset4"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Memset4(IntPtr dst, uint val, UIntPtr dwords);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_memcmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Memcmp(IntPtr s1, IntPtr s2, UIntPtr len);

    // wchar_t helpers (marshalled as raw pointers; wchar_t width is platform-dependent)
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcslen"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Wcslen(IntPtr wstr);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcsnlen"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Wcsnlen(IntPtr wstr, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcslcpy"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Wcslcpy(IntPtr dst, IntPtr src, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcslcat"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Wcslcat(IntPtr dst, IntPtr src, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcsdup"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Wcsdup(IntPtr wstr);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcsstr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Wcsstr(IntPtr haystack, IntPtr needle);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcsnstr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Wcsnstr(IntPtr haystack, IntPtr needle, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcscmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Wcscmp(IntPtr str1, IntPtr str2);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcsncmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Wcsncmp(IntPtr str1, IntPtr str2, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcscasecmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Wcscasecmp(IntPtr str1, IntPtr str2);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcsncasecmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Wcsncasecmp(IntPtr str1, IntPtr str2, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_wcstol"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long Wcstol(IntPtr str, out IntPtr endp, int @base);

    // UTF-8 string helpers
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strlen"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Strlen([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strnlen"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Strnlen([MarshalAs(UnmanagedType.LPUTF8Str)] string str, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strlcpy"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Strlcpy(IntPtr dst, [MarshalAs(UnmanagedType.LPUTF8Str)] string src, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_utf8strlcpy"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Utf8Strlcpy(IntPtr dst, [MarshalAs(UnmanagedType.LPUTF8Str)] string src, UIntPtr dstBytes);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strlcat"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Strlcat(IntPtr dst, [MarshalAs(UnmanagedType.LPUTF8Str)] string src, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strdup"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strdup([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strndup"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strndup([MarshalAs(UnmanagedType.LPUTF8Str)] string str, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strrev"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strrev(IntPtr str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strupr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strupr(IntPtr str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strlwr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strlwr(IntPtr str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strchr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strchr([MarshalAs(UnmanagedType.LPUTF8Str)] string str, int c);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strrchr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strrchr([MarshalAs(UnmanagedType.LPUTF8Str)] string str, int c);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strstr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strstr([MarshalAs(UnmanagedType.LPUTF8Str)] string haystack, [MarshalAs(UnmanagedType.LPUTF8Str)] string needle);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strnstr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strnstr([MarshalAs(UnmanagedType.LPUTF8Str)] string haystack, [MarshalAs(UnmanagedType.LPUTF8Str)] string needle, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strcasestr"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strcasestr([MarshalAs(UnmanagedType.LPUTF8Str)] string haystack, [MarshalAs(UnmanagedType.LPUTF8Str)] string needle);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strtok_r"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr StrtokR(IntPtr str, [MarshalAs(UnmanagedType.LPUTF8Str)] string delim, ref IntPtr saveptr);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_utf8strlen"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Utf8Strlen([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_utf8strnlen"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Utf8Strnlen([MarshalAs(UnmanagedType.LPUTF8Str)] string str, UIntPtr bytes);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_itoa"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Itoa(int value, IntPtr str, int radix);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_uitoa"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Uitoa(uint value, IntPtr str, int radix);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_ltoa"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Ltoa(long value, IntPtr str, int radix);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_ultoa"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Ultoa(ulong value, IntPtr str, int radix);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_lltoa"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Lltoa(long value, IntPtr str, int radix);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_ulltoa"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Ulltoa(ulong value, IntPtr str, int radix);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_atoi"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Atoi([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_atof"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double Atof([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strtol"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long Strtol([MarshalAs(UnmanagedType.LPUTF8Str)] string str, out IntPtr endp, int @base);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strtoul"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong Strtoul([MarshalAs(UnmanagedType.LPUTF8Str)] string str, out IntPtr endp, int @base);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strtoll"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long Strtoll([MarshalAs(UnmanagedType.LPUTF8Str)] string str, out IntPtr endp, int @base);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strtoull"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong Strtoull([MarshalAs(UnmanagedType.LPUTF8Str)] string str, out IntPtr endp, int @base);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strtod"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double Strtod([MarshalAs(UnmanagedType.LPUTF8Str)] string str, out IntPtr endp);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strcmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Strcmp([MarshalAs(UnmanagedType.LPUTF8Str)] string str1, [MarshalAs(UnmanagedType.LPUTF8Str)] string str2);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strncmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Strncmp([MarshalAs(UnmanagedType.LPUTF8Str)] string str1, [MarshalAs(UnmanagedType.LPUTF8Str)] string str2, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strcasecmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Strcasecmp([MarshalAs(UnmanagedType.LPUTF8Str)] string str1, [MarshalAs(UnmanagedType.LPUTF8Str)] string str2);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strncasecmp"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Strncasecmp([MarshalAs(UnmanagedType.LPUTF8Str)] string str1, [MarshalAs(UnmanagedType.LPUTF8Str)] string str2, UIntPtr maxlen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_strpbrk"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Strpbrk([MarshalAs(UnmanagedType.LPUTF8Str)] string str, [MarshalAs(UnmanagedType.LPUTF8Str)] string breakset);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_StepUTF8"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint StepUtf8(ref IntPtr pstr, ref UIntPtr pslen);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_StepBackUTF8"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint StepBackUtf8(IntPtr start, ref IntPtr pstr);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_UCS4ToUTF8"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr Ucs4ToUtf8(uint codepoint, IntPtr dst);

    // iconv
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_iconv_open"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr IconvOpen(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string tocode,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fromcode
    );

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_iconv_close"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IconvClose(IntPtr cd);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_iconv"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr Iconv(
        IntPtr cd,
        ref IntPtr inbuf,
        ref UIntPtr inbytesleft,
        ref IntPtr outbuf,
        ref UIntPtr outbytesleft
    );

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_iconv_string"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr IconvString(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string tocode,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fromcode,
        IntPtr inbuf,
        UIntPtr inbytesleft
    );

    // overflow helpers
    [LibraryImport(SDLLibrary, EntryPoint = "SDL_size_mul_check_overflow"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool SizeMulCheckOverflow(UIntPtr a, UIntPtr b, out UIntPtr ret);

    [LibraryImport(SDLLibrary, EntryPoint = "SDL_size_add_check_overflow"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool SizeAddCheckOverflow(UIntPtr a, UIntPtr b, out UIntPtr ret);
}
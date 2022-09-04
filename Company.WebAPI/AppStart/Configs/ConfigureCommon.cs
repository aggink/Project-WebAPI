namespace Company.WebAPI.AppStart.Configs;

public static class ConfigureCommon
{
    /// <summary>
    /// AddBaseConfigureServices pipeline
    /// </summary>
    /// <param name="app">Интерфейс, предоставляющий механизмы настройки конвейера запросов приложения.</param>
    /// <param name="env">Интерфейс, предоставляющий ведения о среде размещения веб-сайтов, в которой выполняется приложение</param>
    /// <param name="mapper">интерфейс, предоставляющий конфигурации для настройки AutoMapper</param>
    /// <returns>Интерфейс, предоставляющий механизмы настройки конвейера запросов приложения.</returns>
    public static IApplicationBuilder AddCommonConfigure(this IApplicationBuilder app, IWebHostEnvironment env, AutoMapper.IConfigurationProvider mapper)
    {
        if (env.IsDevelopment())
        {
            mapper.AssertConfigurationIsValid();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
            mapper.CompileMappings();
        }

        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
            }
        });

        app.UseResponseCaching();
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
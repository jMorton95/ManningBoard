module.exports = {
  overrides: [
    {
      plugins: ['@typescript-eslint', 'prettier', 'react-refresh'],
      extends: [
        'plugin:@typescript-eslint/recommended', 
        'prettier', 
        'eslint:recommended',
        'plugin:@typescript-eslint/recommended-requiring-type-checking',
        'plugin:react-hooks/recommended'
      ],
      parser: '@typescript-eslint/parser',
      parserOptions: {
        ecmaVersion: 'latest',
        sourceType: 'module',
        project: './tsconfig.json',
      },
      files: ['*.ts', '*.tsx'],
    }
  ],
  rules: {
    '@typescript-eslint/consistent-type-imports': [
      'warn',
      {
        prefer: 'type-imports',
        fixStyle: 'inline-type-imports'
      }
    ],
    '@typescript-eslint/no-unused-vars': ['warn', { argsIgnorePattern: '^_' }],
    'indent': 'off',
    '@typescript-eslint/indent': ['error', 2]
  }
};

